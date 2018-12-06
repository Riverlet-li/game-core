using System;
using System.Collections.Generic;
using System.IO;

namespace GameCore
{
    public class TableRowBuffer
    {
        private int _idx = -1;
        private List<string> _data = null;
        private TableBuffer _buffer = null;

        public TableRowBuffer(TableBuffer buffer, int idx)
        {
            _idx = idx;
            _data = new List<string>();
            _buffer = buffer;
        }

        public string GetDataByIdx(int idx)
        {
            if (idx < 0 || idx >= _data.Count) { return string.Empty; }
            return _data[idx];
        }

        public string GetDataByName(string fieldName)
        {
            int idx = _buffer.GetFieldIdx(fieldName);
            return GetDataByIdx(idx);
        }

        public int Idx { get { return _idx; } }
        public bool HasFields { get { return (_data != null && _data.Count > 0); } }

        public List<string> Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }

    public class TableBuffer
    {
        private List<string> _fileds;
        private List<TableRowBuffer> _data;
        private Dictionary<string, TableRowBuffer> _hashData;
        private int _rowCnt;
        private int _colCnt;
        private string _filePath;
        private string[] _split;

        public TableBuffer(string path)
        {
            _fileds = new List<string>();
            _data = new List<TableRowBuffer>();
            _hashData = new Dictionary<string, TableRowBuffer>();
            _filePath = path;
            _rowCnt = 0;
            _colCnt = 0;
            _split = new string[] { "\t" };
        }

        public int RowCnt { get { return _rowCnt; } }
        public int ColCnt { get { return _colCnt; } }
        public List<string> Fields { get { return _fileds; } }
        public string FileName { get { return _filePath; } }

        public string GetFieldName(int index)
        {
            if (_fileds == null || _fileds.Count == 0) { return string.Empty; }
            if (index < 0 || index >= _fileds.Count) { return string.Empty; }
            return _fileds[index];
        }
        public int GetFieldIdx(string name)
        {
            if (_fileds == null || _fileds.Count == 0) { return -1; }
            for (int idx = 0; idx < _fileds.Count; idx++) {
                if (name == _fileds[idx]) {
                    return idx;
                }
            }
            return -1;
        }

        public TableRowBuffer GetRowBuffer(int idx)
        {
            if (idx < 0 || idx >= _rowCnt) return null;
            if (_data != null && idx >= _data.Count) return null;
            return _data[idx];
        }

        public string GetData(int rowIdx, int colIdx)
        {
            if (rowIdx < 0 || rowIdx >= _rowCnt || colIdx < 0 || colIdx >= _colCnt) return string.Empty;

            TableRowBuffer dbRow = GetRowBuffer(rowIdx);
            if (dbRow != null) {
                return dbRow.GetDataByIdx(colIdx);
            }
            return string.Empty;
        }

        public string GetData(string id, string fieldName)
        {
            TableRowBuffer row;
            int idx = this.GetFieldIdx(fieldName);
            if (_hashData.ContainsKey(id)) {
                row = _hashData[id];
                if (row != null && idx >= 0) {
                    return row.GetDataByIdx(idx);
                }
            }
            return string.Empty;
        }

        public void Load()
        {
            MemoryStream ms = null;
            StreamReader sr = null;
            byte[] buffer = null;

            try {
                buffer = File.ReadAllBytes(_filePath);
                ms = new MemoryStream(buffer);
                ms.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(ms, System.Text.Encoding.UTF8);
                ParseStream(sr);
            } catch (Exception e) {
                GameLog.Error("TableBuffer Load failed.file({0}) Exception:{1}\n{2}",
                    _filePath, e.Message, e.StackTrace);
            } finally {
                if (sr != null) { sr.Close(); sr = null; }
                if (ms != null) { ms.Close(); ms = null; }
            }
        }

        private void ParseStream(StreamReader sr)
        {
            //--------------------------------------------------------------
            //临时变量
            string[] dataArray = null;
            string strLine = "";

            //读第一行,标题行
            strLine = sr.ReadLine();
            //读取失败，即认为读取结束
            if (strLine == null) {
                throw new Exception("TableBuffer Field null.");
            }

            dataArray = strLine.Split(_split, StringSplitOptions.None);
            if (dataArray == null || dataArray.Length == 0) {
                throw new Exception("TableBuffer Field split failed.");
            }
            this._fileds = new List<string>(dataArray);

            //--------------------------------------------------------------
            //初始化
            int rowIdx = 0;
            int fieldCnt = dataArray.Length;

            //--------------------------------------------------------------
            //开始读取
            TableRowBuffer rowBuffer = null;
            List<string> dataList = null;
            do {
                rowBuffer = null;

                //读取一行
                strLine = sr.ReadLine();
                //读取失败，即认为读取结束
                if (strLine == null) break;

                //是否是注释行
                if (strLine.Trim().StartsWith("#")) continue;
                if (strLine.Trim().StartsWith("\"#")) continue;

                //分解
                dataArray = strLine.Split(_split, StringSplitOptions.None);
                //第一列不能为空
                if (string.IsNullOrEmpty(dataArray[0])) continue;
                //列数不对
                if (dataArray == null || dataArray.Length == 0) continue;

                dataList = new List<string>(dataArray);
                if (dataArray.Length != fieldCnt) {
                    //补上空格
                    if (dataArray.Length < fieldCnt) {
                        int nSubNum = fieldCnt - dataArray.Length;
                        for (int i = 0; i < nSubNum; i++) {
                            dataList.Add("");
                        }
                    }
                }

                rowBuffer = new TableRowBuffer(this, rowIdx);
                rowBuffer.Data = dataList;
                _data.Add(rowBuffer);
                rowIdx++;
            } while (true);

            //--------------------------------------------------------
            //生成正式数据库
            _colCnt = fieldCnt;
            _rowCnt = rowIdx;
            //创建索引
            CreateIndex();
        }
        private void CreateIndex()
        {
            foreach (TableRowBuffer row in _data) {
                if (row.Data != null && row.Data.Count > 0) {
                    string id = row.Data[0];
                    if (!_hashData.ContainsKey(id)) {
                        _hashData.Add(id, row);
                    } else {
                        GameLog.Error("TableBuffer CreateIndex failed. same key({0}) file({1})", id, _filePath);
                    }
                }
            }
        }
    }
}

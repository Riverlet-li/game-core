using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public abstract class IConfig
    {
        public abstract int GetId();
        public virtual void Load(TableRowBuffer row) { }
        protected abstract void OnLoadConfig();
    }

    public abstract class ITable<TData> where TData : IConfig, new()
    {
        private Dictionary<int, TData> _dict = new Dictionary<int, TData>();

        protected abstract void OnLoadTable();

        public void Load(string path)
        {
            TableBuffer document = new TableBuffer(path);
            document.Load();
            for (int index = 0; index < document.RowCnt; index++) {
                TableRowBuffer node = document.GetRowBuffer(index);
                try {
                    TData data = new TData();
                    data.Load(node);
                    Add(data);
                    
                } catch (System.Exception ex) {
                    GameLog.Error("ITable load file({0}) row(1) failed.Exception:{2}\n{3}", 
                        path, node.Idx, ex.Message, ex.StackTrace);
                }
            }
            OnLoadTable();
            GameLog.Info("ITable load file({0}) done.", path);
        }

        protected void Add(TData config)
        {
            if (!_dict.ContainsKey(config.GetId())) {
                _dict.Add(config.GetId(), config);
            } else {
                throw new Exception(string.Format("ITable same id({0})", config.GetId()));
            }
        }
        public TData Get(int id)
        {
            if (_dict.ContainsKey(id)) {
                return _dict[id];
            }
            return null;
        }
    }
}

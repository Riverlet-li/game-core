using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public partial class ConfigScene : IConfig
    {
        public int m_Id;
        public string m_Name;
        public int m_Type;
        public string m_Res;

        public override void Load(TableRowBuffer buffer)
        {
            m_Id = TableExtracter.ExtractNumeric<int>(buffer, "Id", 0);
            m_Name = TableExtracter.ExtractString(buffer, "Name", "");
            m_Type = TableExtracter.ExtractNumeric<int>(buffer, "Type", 0);
            m_Res = TableExtracter.ExtractString(buffer, "Res", "");
            OnLoadConfig();
        }
        public override int GetId()
        {
            return m_Id;
        }
    }

    public partial class TableScene : ITable<ConfigScene> { }
}

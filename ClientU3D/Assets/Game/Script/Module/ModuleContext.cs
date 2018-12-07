using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class ModuleContext
    {
        public static TableModule tableModule = new TableModule();
        public static void Init()
        {
            tableModule.Load();
        }
    }
}

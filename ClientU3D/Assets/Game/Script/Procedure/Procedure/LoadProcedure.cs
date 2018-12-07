using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class LoadProcedure : IProcedure
    {
        public bool isLoadDone = false;
        public override void Reset()
        {
            isLoadDone = false;
        }
    }
}

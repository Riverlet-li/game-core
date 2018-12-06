using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public abstract class IService
    {
        public static ServiceContext service = null;
        public static EntityContext entity = null;
        public abstract void Init();
        public abstract void Release();
    }
}

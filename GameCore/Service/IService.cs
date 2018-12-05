﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    abstract class IService
    {
        public abstract void Init();
        public abstract void Release();
        public abstract void Tick();
    }
}

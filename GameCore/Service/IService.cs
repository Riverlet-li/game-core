using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    interface IService
    {
        void Init();
        void Release();
        void Tick();
    }
}

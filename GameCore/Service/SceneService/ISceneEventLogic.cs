using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    abstract class ISceneEventLogic
    {
        public abstract void Execute(SceneData data);
    }
}

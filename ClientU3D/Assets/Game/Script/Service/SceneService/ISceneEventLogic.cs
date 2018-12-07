using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public abstract class ISceneEventLogic
    {
        public abstract void Execute(SceneEntity data);
    }
}

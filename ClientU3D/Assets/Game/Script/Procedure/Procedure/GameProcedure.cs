using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class GameProcedure : IProcedure
    {
        public bool isLoadDone = false;
        public SceneObject sceneObj = null;

        public override void Reset()
        {
            isLoadDone = false;
            sceneObj = null;
        }
    }
}

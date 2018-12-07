using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class GameConfig
    {
        public string tablePath = "";

        // Procedure Service
        public string startProcedure = "LoadScene";
        public string targetProcedure = "GameScene";
        public int targetSceneId = 1001;

        // Scene Service
        public bool isSvrScene = true;

        public GameConfig() { }
    }
}

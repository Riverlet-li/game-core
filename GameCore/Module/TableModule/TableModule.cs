using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class TableModule
    {
        private TableScene tableScene = new TableScene();

        public void Init()
        {
            tableScene.Load(TablePath.C_SceneConfig);
        }


        /////////////////////////////////////////////////////////////
        // Scene
        public TableScene GetTableScene() { return tableScene; }
        public ConfigScene GetConfigScene(int key) { return tableScene.Get(key); }

        ///////////////////////////////////////////////////////////// 
        private string ConvertClientPath(string path)
        {
            return System.IO.Path.Combine("", path);
        }
    }
}

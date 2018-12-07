using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class SceneObject
    {
        public int sceneId = 0;
        public string sceneName = "";
        public int sceneType = 0;
        public string sceneResName = "";

        public ConfigScene cfgScene = null;

        public UnityEngine.SceneManagement.Scene sceneRes;
        public UserObjMgr userMgr = null;
        public NpcObjMgr npcMgr = null;
        public UserObj userSelf = null;
    }
}

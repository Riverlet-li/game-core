using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class EntityContext
    {
        public static SceneEntity sceneEntity = null;
        public static ActorEntityMgr actorEntityMgr = null;
        public static StoryEntity storyEntity = null;

        public static void Init()
        {
            sceneEntity = null;
            actorEntityMgr = new ActorEntityMgr();
            storyEntity = null;
        }

        public static void Release()
        {
            sceneEntity = null;
        }
    }
}

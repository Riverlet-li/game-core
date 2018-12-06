using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class EntityContext
    {
        public SceneEntity sceneEntity = null;
        public ActorEntityMgr actorEntityMgr = null;
        public StoryEntity storyEntity = null;

        public void Init()
        {
            sceneEntity = null;
            actorEntityMgr = new ActorEntityMgr();
            storyEntity = null;
        }

        public void Release()
        {
            sceneEntity = null;
        }
    }
}

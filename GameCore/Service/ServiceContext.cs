using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class ServiceContext
    {
        public ActorService actorService = null;
        public SceneService sceneService = null;
        public SkillService skillService = null;
        public StoryService storyService = null;

        public void Init()
        {
            actorService = new ActorService();
            actorService.Init();

            sceneService = new SceneService();
            sceneService.Init();

            skillService = new SkillService();
            skillService.Init();

            storyService = new StoryService();
            storyService.Init();
        }

        public void Release()
        {
            actorService.Release();
            sceneService.Release();
            skillService.Release();
            storyService.Release();
        }
    }
}

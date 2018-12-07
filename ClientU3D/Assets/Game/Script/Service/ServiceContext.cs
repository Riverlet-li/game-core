using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class ServiceContext
    {
        public static ActorService actorService = null;
        public static SceneService2 sceneService = null;
        public static SkillService skillService = null;
        public static StoryService storyService = null;
        public static UIService uiService = null;

        public static void Init()
        {
            actorService = new ActorService();
            actorService.Init();

            sceneService = new SceneService2();
            sceneService.Init();

            skillService = new SkillService();
            skillService.Init();

            storyService = new StoryService();
            storyService.Init();

            uiService = new UIService();
            uiService.Init();
        }

        public static void Release()
        {
            actorService.Release();
            sceneService.Release();
            skillService.Release();
            storyService.Release();
            uiService.Release();
        }
    }
}

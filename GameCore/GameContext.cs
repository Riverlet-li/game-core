using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class GameContext
    {
        public static bool isExit = false;
        public static void Init() {
            Services.Add<SceneService>(new SceneService());
            Services.Add<SkillService>(new SkillService());

            Services.Get<SceneService>().EnterScene(0);
        }
        public static void Release() {
            Services.Del<SceneService>(new SceneService());
            Services.Del<SkillService>(new SkillService());
        }
        public static void Tick() {
            Services.Tick();
        }
    }
}

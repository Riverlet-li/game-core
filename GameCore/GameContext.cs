using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class GameContext
    {
        public static bool isExit = false;
        private static EntityContext _entityCxt = null;
        private static ServiceContext _serviceCxt = null;

        public static void InitGame()
        {
            // data
            _entityCxt = new EntityContext();
            IService.entity = _entityCxt;
            _entityCxt.Init();

            // service
            _serviceCxt = new ServiceContext();
            IService.service = _serviceCxt;
            _serviceCxt.Init();
        }

        public static void StartGame()
        {
            _serviceCxt.sceneService.EnterScene(0);
        }

        public static void QuitGame()
        {
            _serviceCxt.Release();
            _entityCxt.Release();
        }

        public static void TickGame()
        {
            _serviceCxt.actorService.Tick(_entityCxt.actorEntityMgr);
            _serviceCxt.sceneService.Tick(_entityCxt.sceneEntity);
            _serviceCxt.storyService.Tick(_entityCxt.storyEntity);
        }
    }
}

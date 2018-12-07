using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameCore
{
    public class GameContext
    {
        public static bool isExit = false;

        // module
        public static TableModule tableModule = null;

        // service
        public static GameConfig gameConfig = null;
        public static ProcedureService procedureSrv = null;
        public static ProcedureFactory procedureFactory = null;
        public static SceneService sceneSrv = null;

        public static void InitGame()
        {
            GameLog.SetPrintHandler(UnityEngine.Debug.LogFormat);

            gameConfig = new GameConfig();
            gameConfig.tablePath = Application.streamingAssetsPath;

            procedureFactory = new ProcedureFactory();
            procedureFactory.Register("LoadScene", new LoadProcedure());
            procedureFactory.Register("MainScene", new MainProcedure());
            procedureFactory.Register("GameScene", new GameProcedure());

            procedureSrv = new ProcedureService();
            procedureSrv.Init();

            sceneSrv = new SceneService();
            sceneSrv.Init();
        }

        public static void StartGame()
        {
            procedureSrv.ChangeProcedure(gameConfig.startProcedure);
        }

        public static void QuitGame()
        {
        }

        public static void TickGame()
        {
        }
    }
}

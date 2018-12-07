/**
  @brief 游戏流程（Procedure）服务
            State模式
            1.LoadProcedure启动后根据GameConfig.targetProcedure决定Load后的下一个Procedure；
            2.各个Procedure分成两部分，IProcedure(数据部分) + IProcedureLogic(逻辑部分)；
            3.ProcedureService提供对外控制接口（API）；
         扩展：
            1.增加更多的Procedure和ProcedureLogic；

  @author lixiaojiang
  @date 2018-12-7
 */

using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class ProcedureService
    {
        private IProcedure _procedure = null;

        public void Init()
        {
            _procedure = null;

            
        }

        public IProcedure GetCurProcedure()
        {
            return _procedure;
        }

        public void ChangeProcedure(string name, int sceneId = 0)
        {
            IProcedure procedure = GameContext.procedureFactory.Get(name);
            if (procedure == null) {
                GameLog.Error("change procedure type error.name({0})", name);
                return;
            }

            procedure.Reset();
            procedure.sceneId = sceneId;
            SceneManager.LoadScene(procedure.procSceneRes);
            _procedure = procedure;
        }
    }
}

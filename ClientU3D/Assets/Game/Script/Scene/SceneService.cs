/**
  @brief 游戏场景服务（特指GamePlay场景）
            Builder模式
            1.SceneService用于创建SceneObject，可理解为SceneObject的Builder；
            2.SceneObject可由两种方式创建:a.GameProcedureLogic和ServerMessageHandler；
            3.SceneObject内维护与场景相关的各种数据，相关接口由ServerService提供；
         扩展：
            1.继承SceneObject得到创造更多特殊场景类型；

  @author lixiaojiang
  @date 2018-12-7
 */

using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class SceneService
    {
        private SceneObject _scenObj = null;
        public void Init()
        {
            _scenObj = null;
        }

        #region SceneObj
        public SceneObject GetSceneObj() { return _scenObj; }
        public SceneObject CreateSceneObj(ConfigScene cfg)
        {
            _scenObj = new SceneObject();
            _scenObj.cfgScene = cfg;
            _scenObj.sceneName = cfg.m_Name;
            _scenObj.sceneType = cfg.m_Type;
            _scenObj.sceneResName = cfg.m_Res;
            return _scenObj;
        }
        #endregion

        #region SceneObject Builder
        // 加载地图资源
        public void LoadMapRes()
        {
            GameLog.Debug("load game scene({0})", _scenObj.sceneResName);
            SceneManager.LoadScene(_scenObj.sceneResName, LoadSceneMode.Additive);
        }

        // 加载地图阻挡信息
        public void LoadMapInfo()
        {
            GameLog.Debug("LoadMapInfo for Level {0}", _scenObj.sceneResName);
        }

        // 增加UserSelf
        public void AddUserSelf(UserObj user)
        {
            GameLog.Debug("AddUserSelf for Level {0}", _scenObj.sceneResName);
        }

        // 增加UserOther
        public void AddUserOther(UserObj user)
        {
            GameLog.Debug("AddUserOther for Level {0}", _scenObj.sceneResName);
        }

        // 增加npc
        public void AddNpcObj(NpcObj npc)
        {
            GameLog.Debug("AddNpcObj for Level {0}", _scenObj.sceneResName);
        }

        // 加载场景剧情
        public void LoadStory()
        {
            GameLog.Debug("LoadStory for Level {0}", _scenObj.sceneResName);
        }

        // 加载场景UI
        public void LoadUI()
        {
            GameLog.Debug("LoadUI for Level {0}", _scenObj.sceneResName);
        }
        #endregion

        #region Scene api
        public void ChangeGameScene(int sceneId)
        {
            ConfigScene cfgScene = GameContext.tableModule.GetConfigScene(sceneId);
            if (cfgScene == null) {
                GameLog.Error("ConfigScene miss.invalid sceneId({0})", sceneId);
                return;
            }

            if (GameContext.gameConfig.isSvrScene) {
                // TODO:发送消息到服务器，请求切换场景
            } else {
                GameContext.procedureSrv.ChangeProcedure("GameScene", sceneId);
            }
        }
        #endregion
    }
}

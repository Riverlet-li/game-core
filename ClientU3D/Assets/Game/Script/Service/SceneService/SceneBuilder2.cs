using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class SceneBuilder2
    {
        private SceneEntity _entity;

        public SceneBuilder2(int sceneId)
        {
            _entity = new SceneEntity();
            _entity.sceneId = sceneId;
        }

        public void LoadConfig(ConfigScene cfgScene)
        {
            _entity.sceneName = cfgScene.m_Name;
            _entity.sceneType = cfgScene.m_Type;
            _entity.sceneRes = cfgScene.m_Res;
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(_entity.sceneRes);
        }

        public SceneEntity GetSceneEntity()
        {
            return _entity;
        }
    }
}

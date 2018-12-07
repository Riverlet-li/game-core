using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class SceneService2 : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        #endregion

        #region public api
        public void Tick(SceneEntity scene)
        {
        }

        public void EnterScene(int sceneId)
        {
            ConfigScene cfgScene = ModuleContext.tableModule.GetConfigScene(sceneId);
            if (cfgScene == null) {
                GameLog.Error("SceneService invalid sceneId({0})", sceneId);
                return;
            }

            SceneEntity sceneData = EntityContext.sceneEntity;
            if (sceneData != null) {
                if (sceneData.sceneId == sceneId) return;
                SceneLogic.OnLeave(sceneData);
            }

            SceneBuilder2 builder = new SceneBuilder2(sceneId);
            builder.LoadConfig(cfgScene);
            builder.LoadLevel();
            //TODO:more action in builder
            sceneData = builder.GetSceneEntity();
            EntityContext.sceneEntity = sceneData;
            SceneLogic.OnEnter(sceneData);
        }



        #endregion
    }
}

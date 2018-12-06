using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class SceneService : IService
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
            SceneEntity sceneData = entity.sceneEntity;
            if (sceneData != null) {
                if (sceneData.sceneId == sceneId) return;
                SceneLogic.OnLeave(sceneData);
            }

            SceneBuilder builder = new SceneBuilder();
            SceneEntity data = builder.GetSceneEntity();
            SceneLogic.OnEnter(data);
        }



        #endregion
    }
}

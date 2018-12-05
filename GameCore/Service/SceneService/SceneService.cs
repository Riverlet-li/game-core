using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class SceneService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        public override void Tick() { }
        #endregion

        #region public api
        public void EnterScene(int sceneId)
        {
            SceneData sceneData = DataSets.sceneData;
            if (sceneData != null) {
                if (sceneData.id == sceneId) return;
                SceneLogic.OnLeave(sceneData);
            }

            SceneData data = new SceneData();
            SceneLogic.OnEnter(data);
        }
        #endregion
    }
}

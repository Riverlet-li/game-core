using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class StoryService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        public override void Tick() { }
        #endregion

        #region public api
        public void StartStory(StoryData data)
        { }
        #endregion
    }
}

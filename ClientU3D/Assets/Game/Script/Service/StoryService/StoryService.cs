using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class StoryService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }
        public void Tick(StoryEntity entity)
        {

        }
        #endregion

        #region public api
        public void StartStory(StoryEntity data)
        { }
        #endregion
    }
}

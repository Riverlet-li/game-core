using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class SkillService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        public void Tick(SkillEntity entity)
        {

        }
        #endregion

        #region public api
        public void StartSkill(SkillEntity data, int skillId, int senderId)
        { }

        public void StopSkill(SkillEntity data, int skillId)
        { }
        #endregion
    }
}

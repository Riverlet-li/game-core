﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class SkillService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        public override void Tick() { }
        #endregion

        #region public api
        public void StartSkill(SkillData data, int skillId, int senderId)
        { }

        public void StopSkill(SkillData data, int skillId)
        { }
        #endregion
    }
}

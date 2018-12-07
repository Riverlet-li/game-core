using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class UserActor : IActorEntity
    {
        public SkillEntity skillEntity = null;
        public AttriEntity attriEntity = null;

        public UserActor()
        {
            skillEntity = new SkillEntity();
            attriEntity = new AttriEntity();
        }
    }
}

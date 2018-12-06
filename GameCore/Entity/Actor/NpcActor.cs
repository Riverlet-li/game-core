using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class NpcActor : IActorEntity
    {
        public SkillEntity skillEntity = null;
        public AttriEntity attriEntity = null;

        public NpcActor()
        {
            skillEntity = new SkillEntity();
            attriEntity = new AttriEntity();
        }
    }
}

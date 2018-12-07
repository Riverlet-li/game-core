using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class ActorService : IService
    {
        #region cycle
        public override void Init() { }

        public override void Release() { }

        public void Tick(ActorEntityMgr mgr)
        {
            mgr.VisitNpcs(TickNpc);
            mgr.VisitUsers(TickUser);
        }

        private void TickNpc(NpcActor npc)
        {
            ServiceContext.skillService.Tick(npc.skillEntity);
        }

        private void TickUser(UserActor user)
        {
            ServiceContext.skillService.Tick(user.skillEntity);
        }
        #endregion

        #region factory
        public UserActor CreateUser() { return null; }

        public NpcActor CreateNpc() { return null; }
        #endregion
    }
}

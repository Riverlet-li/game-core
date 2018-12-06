using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{

    public delegate void VisitNpcHandler(NpcActor npc);
    public delegate void VisitUserHandler(UserActor user);
    public class ActorEntityMgr
    {
        private Dictionary<int, NpcActor> _npcs = null;
        private Dictionary<int, UserActor> _users= null;

        public ActorEntityMgr()
        {
            _npcs = new Dictionary<int, NpcActor>();
            _users = new Dictionary<int, UserActor>();
        }

        public NpcActor GetNpc(int id) { return null; }
        public UserActor GetUser(int id) { return null; }

        public void AddNpc(NpcActor npc) { }
        public void AddUser(UserActor user) { }

        public void DelNpc(int id) { }
        public void DelUser(int id) { }

        public void VisitNpcs(VisitNpcHandler handler)
        {
        }

        public void VisitUsers(VisitUserHandler handler)
        {
        }
    }
}

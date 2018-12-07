using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public abstract class IProcedure
    {
        public string procName { get; set; }
        public string procSceneRes { get; set; }
        public int sceneId { get; set; }
        public abstract void Reset();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class ProcedureFactory
    {
        private Dictionary<string, IProcedure> _procedures = new Dictionary<string, IProcedure>();

        public void Register(string name, IProcedure proc)
        {
            if (!_procedures.ContainsKey(name)) {
                proc.procName = name;
                proc.procSceneRes = name;
                _procedures.Add(name, proc);
            } else {
                GameLog.Warn("register same procedure, name({0})", name);
            }
        }

        public IProcedure Get(string name)
        {
            if (_procedures.ContainsKey(name)) {
                return _procedures[name];
            }
            return null;
        }

        public T Get<T>() where T : IProcedure
        {
            Type type = typeof(T);
            foreach (var item in _procedures.Values) {
                if (type == item.GetType()) {
                    return (T)(item);
                }
            }
            return null;
        }
    }
}

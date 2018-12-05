using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class Services
    {
        private static Dictionary<Type, IService> _services = null;

        static Services()
        {
            _services = new Dictionary<Type, IService>();
        }

        public static T Get<T>() where T : IService
        {
            Type type = typeof(T);
            if (_services.ContainsKey(type)) {
                return (T)(_services[type]);
            }
            return null;
        }

        public static T Add<T>(T service) where T : IService
        {
            Type type = typeof(T);
            if (!_services.ContainsKey(type)) {
                _services.Add(type, service);
                service.Init();
            }
            return service;
        }

        public static void Del<T>(T service) where T : IService
        {
            Type type = typeof(T);
            if (_services.ContainsKey(type)) {
                _services.Remove(type);
                service.Release();
            }
        }

        public static void Tick()
        {
            foreach (IService service in _services.Values) {
                service.Tick();
            }
        }
    }
}

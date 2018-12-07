using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public class Singleton
    {
        private static Dictionary<Type, Singleton> _registery = new Dictionary<Type, Singleton>();

        protected Singleton() { }
        // 通过泛型查找
        public static T Instance<T>() where T : Singleton, new()
        {
            Type type = typeof(T);
            T inst = null;
            if (_registery.ContainsKey(type)) {
                inst = (T)_registery[type];
            } else {
                inst = new T();
            }
            return inst;
        }
        // 建立singeton索引表
        public static void Register<T>(T inst) where T : Singleton
        {
            if (!_registery.ContainsKey(typeof(T))) {
                _registery.Add(typeof(T), inst);
            } else {
                throw new Exception("Register duplicate instance.");
            }
        }
    }
}

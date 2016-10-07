using System;
using System.Linq;
using System.Reflection;
using Core.Interfaces;

namespace Core.Command
{
    public abstract class AParametr<TParam> : IParametr where TParam : class
    {
        private readonly TParam _instance;
        //private readonly Dictionary<>

        protected AParametr(TParam obj)
        {
            _instance = obj;
        }

        protected AParametr()
        {

        }

        public T GetValue<T>(string key)
        {
            var property = typeof(TParam).GetProperties(BindingFlags.Public).SingleOrDefault(p => p.Name == key);
            if (property == null)
                throw new ArgumentException($"Can't find property by key {key}");
            var result = property.GetValue(_instance, null);
            if (result is T)
                return (T)result;
            throw new InvalidCastException($"Can't cast {result.GetType()} to {typeof(T)}");
        }

        public static TParam CreateParam<TParam>() where TParam : new()
        {
            return new TParam();
        }
    }
}


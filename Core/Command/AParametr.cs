using System;
using System.Linq;
using System.Reflection;
using Core.Interfaces;
using ProtoBuf;

namespace Core.Command
{
    [ProtoContract]
    public abstract class AParametr<TParam> : IParametr where TParam : class
    {
        private readonly object _instance;

        protected AParametr()
        {
            _instance = this;
        }

        public T GetValue<T>(string key)
        {
            var property = typeof(TParam).GetProperties().SingleOrDefault(p => p.Name == key);
            if (property == null)
                throw new ArgumentException($"Can't find property by key {key}");
            var result = property.GetValue(_instance, null);
            if (result is T)
                return (T)result;
            throw new InvalidCastException($"Can't cast {result.GetType()} to {typeof(T)}");
        }

        public string GetValue(string key)
        {
            throw new NotImplementedException();
        }

        public static TParam CreateParam<TParam>() where TParam : new()
        {
            return new TParam();
        }
    }
}


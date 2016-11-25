using System;
using System.Collections.Generic;
using System.Reflection;
using Core.Services;

namespace Core
{
    /// <summary>
    /// Container for Service objects
    /// </summary>
    public sealed class ServiceContainer : Singleton<ServiceContainer>
    {
        private readonly ILoggerService _loggerService;
        private readonly Dictionary<Type, object> _dictionary;

        private ServiceContainer()
        {
            _loggerService = new LoggerService();
            if (_dictionary == null)
                _dictionary = new Dictionary<Type, object>();
        }

        public T Get<T>()
        {
            if (_dictionary.ContainsKey(typeof(T)))
                return (T)_dictionary[typeof(T)];
            return default(T);
        }

        public void SetAs(Type type, object obj)
        {
            if (_dictionary.ContainsKey(type))
                throw new ArgumentException("Type already exist");
            _dictionary.Add(type, obj);
            _loggerService.Trace($"Add to container {type}");
        }

        public void SetAs<T>(object obj)
        {
            if (_dictionary.ContainsKey(typeof(T)))
                throw new ArgumentException("Type already exist");
            _dictionary.Add(typeof(T), obj);
            _loggerService.Trace($"Add to container {typeof(T)}");
        }

        public void SetAs<T>(string className)
        {
            var assembly = typeof(T).GetTypeInfo().Module.Assembly;
            var type = Type.GetType($"{className}, {assembly}");
            if (type == null)
                throw new ArgumentException($"Type with name {className} not found!");
            SetAs<T>(Activator.CreateInstance(type));
            _loggerService.Trace($"Add to container {type} from {assembly}");
        }

        public void SetAs<T>(string className, string assemblyName)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            if (assembly == null)
                throw new ArgumentException($"Assembly with name {className} not found!");
            var type = Type.GetType($"{className}, {assembly}");
            if (type == null)
                throw new ArgumentException($"Type with name {className} not found!");
            SetAs<T>(Activator.CreateInstance(type));
            _loggerService.Trace($"Add to container {type} from {assembly}");
        }
    }
}

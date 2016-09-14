using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Core
{
    public static class CoreFactory
    {
        public static ICoreFactory GetFactory<T>()
        {
            if (typeof(T) == typeof(IPlayer))
                return new CoreFactoryGeneric<Player>();
            throw new ArgumentException($"Can't find Factory by type {typeof(T)}");
        }

        private class CoreFactoryGeneric<TObj> : ICoreFactory where TObj : new()
        {
            public T Create<T>()
            {
                var type = typeof(TObj);

                if (type.IsInterface || type.IsAbstract)
                    throw new ArgumentException("Can't implement interface or abstract class");
                dynamic obj = new TObj();
                return (T)obj;
            }
        }
    }
}

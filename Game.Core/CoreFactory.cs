using System;
using Core.Interfaces;

namespace Game.Core
{
    public static class CoreFactory
    {
        public static IFactory GetFactory<T>()
        {
            if (typeof(T) == typeof(IGame))
                return new CoreFactoryGeneric<GameCore>();
            if (typeof(T) == typeof(IPlayer))
                return new CoreFactoryGeneric<Player>();
            if (typeof(T) == typeof(IUser))
                return new CoreFactoryGeneric<User>();
            throw new ArgumentException($"Can't find Factory by type {typeof(T)}");
        }

        private class CoreFactoryGeneric<TObj> : IFactory where TObj : new()
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

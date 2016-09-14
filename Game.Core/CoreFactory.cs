using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Core
{
    public static class CoreFactory<T>
    {
        public static ICoreFactory<T> GetFactory()
        {
            if (typeof(T) == typeof(IPlayer))
            {
                return new CoreFactoryGeneric<Player>() as ICoreFactory<IPlayer>;
            else
                return null;
            }

        private class CoreFactoryGeneric<Tobj> : ICoreFactory<T> where Tobj : T, new()
        {
            public T Create()
            {
                var type = typeof(Tobj);

                if (type.IsInterface || type.IsAbstract)
                    throw new ArgumentException("Can't implement interface or abstract class");

                return new Tobj();
            }
        }
    }
}

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
                return new CoreFactoryGeneric<Player>() as ICoreFactory<T>;
            else
                return null;
        }

        private class CoreFactoryGeneric<Tobj> : ICoreFactory<T> where Tobj : new()
        {
            public T Create()
            {
                return new Tobj();
            }
        }
    }
}

using System;
using Core.Interfaces;

namespace Core
{
    /// <summary>
    /// Command factory. Abstract foctory for creation command objects
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFactory GetFactory<T>()
        {
            return new FactoryGeneric<Command<T>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        private class FactoryGeneric<TObj> : IFactory where TObj : new()
        {
            /// <summary>
            /// Implementation of this method must create T object
            /// </summary>
            /// <typeparam name="T">Type of object </typeparam>
            /// <returns></returns>
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

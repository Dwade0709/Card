using System;
using Core.Interfaces;

namespace Core.Command
{
    /// <summary>
    /// Command factory. Abstract foctory for creation command objects
    /// </summary>
    public static class CommandFactory<T> where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ICommandFactory<T> GetFactory()
        {
            return new FactoryGeneric<T>() as ICommandFactory<T>;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        private class FactoryGeneric<TObj> : ICommandFactory<T> where TObj : new()
        {
            /// <summary>
            /// Implementation of this method must create T object
            /// </summary>
            /// <typeparam name="T">Type of object </typeparam>
            /// <returns></returns>
            private T Create<T>()
            {
                var type = typeof(TObj);

                if (type.IsInterface || type.IsAbstract)
                    throw new ArgumentException("Can't implement interface or abstract class");
                dynamic obj = new TObj();
                return (T)obj;
            }

            public ACommand<T> Create(Action<IParametr> command)
            {
                throw new NotImplementedException();
            }

            public ACommand<T> Create(Action<IParametr> command, IParametr param)
            {
                throw new NotImplementedException();
            }

            public ACommand<T> Create(IParametr param)
            {
                throw new NotImplementedException();
            }
        }
    }
}

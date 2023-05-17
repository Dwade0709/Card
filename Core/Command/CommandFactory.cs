using System;
using System.Reflection;
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
            return new FactoryGeneric<T>();
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
                var type = typeof(TObj).GetTypeInfo();

                if (type.IsInterface || type.IsAbstract)
                    throw new ArgumentException("Can't implement interface or abstract class");
                dynamic obj = new TObj();
                return (T)obj;
            }

            public ACommand Create(Action<IParametr> command)
            {
                var acommand = Create<T>() as ACommand;
                acommand?.SetAction(command);
                return acommand;
            }

            public ACommand Create(Action<IParametr> command, IParametr param)
            {
                var acommand = Create<T>() as ACommand;
                acommand?.SetAction(command);
                acommand?.SetParametr(param);
                return acommand;

            }

            public ACommand Create(IParametr param)
            {
                var command = Create<T>() as ACommand;
                command?.SetParametr(param);
                return command;
            }

            public ACommand Create()
            {
                return Create<T>() as ACommand;
            }
        }
    }
}

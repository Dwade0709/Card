using System;
using Core.Command;
using Core.Interfaces;

namespace Core.Package
{
    /// <summary>
    /// Package factory. Factory for creating packages 
    /// </summary>
    public class PackageFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> Type of factory what need </typeparam>
        /// <returns></returns>
        public static IPackageFactory<T> GetFactory<T>()
        {
            if (typeof(T) == typeof(ICommandPackage))
                return new CommandPackageFactory<CommandPackage>() as IPackageFactory<T>;

            return new ShortPackageFactory<ShortPackage>() as IPackageFactory<T>;
        }

        /// <summary>
        /// Private generic factory class. Implementation for IPackageFactory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class CommandPackageFactory<T> : IPackageFactory<T> where T : ICommandPackage, new()
        {
            /// <summary>
            ///Create empty object 
            /// </summary>
            /// <returns>T object</returns>
            public T Create()
            {
                return new T();
            }

            /// <summary>
            /// Create object with present client id
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite)
            {
                return new T { ClientId = id, OperationId = operationId, IsAsync = isAsync, IsAwaite = isAwaite };
            }

            /// <summary>
            /// Create Command package. ICommandPackage
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <param name="type"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ECommandType type, DynamicParam param)
            {
                return new T { ClientId = id, OperationId = operationId, IsAsync = isAsync, IsAwaite = isAwaite, Type = type, Params = param };
            }

            /// <summary>
            /// Create short package. IShortPackage
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <param name="command">Command. Implementation ICommand</param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ICommand command)
            {
                throw new ArgumentException($"Can't create {typeof(T)} by this method");
            }
        }

        /// <summary>
        /// Private generic factory class. Implementation for IPackageFactory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class ShortPackageFactory<T> : IPackageFactory<T> where T : IShortPackage, new()
        {
            /// <summary>
            ///Create empty object 
            /// </summary>
            /// <returns>T object</returns>
            public T Create()
            {
                return new T();
            }

            /// <summary>
            /// Create object with present client id
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite)
            {
                return new T { ClientId = id, OperationId = operationId, IsAsync = isAsync, IsAwaite = isAwaite };
            }

            /// <summary>
            /// Create Command package. ICommandPackage
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <param name="type"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ECommandType type, DynamicParam param)
            {
                throw new ArgumentException($"Can't create {typeof(T)} by this method");
            }

            /// <summary>
            /// Create short package. IShortPackage
            /// </summary>
            /// <param name="id">Client id</param>
            /// <param name="operationId">Operation id</param>
            /// <param name="isAsync">Async operation</param>
            /// <param name="isAwaite">Awaite result</param>
            /// <param name="command">Command. Implementation ICommand</param>
            /// <returns></returns>
            public T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ICommand command)
            {
                return new T { ClientId = id, OperationId = operationId, IsAsync = isAsync, IsAwaite = isAwaite, Command = command };
            }
        }
    }
}

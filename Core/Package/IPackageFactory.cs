using System;
using Core.Command;
using Core.Interfaces;

namespace Core.Package
{
    public interface IPackageFactory<out T>
    {
        /// <summary>
        ///Create empty object 
        /// </summary>
        /// <returns>T object</returns>
        T Create();

        /// <summary>
        /// Create object with present client id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="operationId">Operation id</param>
        /// <param name="isAsync">Async operation</param>
        /// <param name="isAwaite">Awaite result</param>
        /// <returns></returns>
        T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite);

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
        T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ECommandType type, DynamicParam param);

        /// <summary>
        /// Create short package. IShortPackage
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="operationId">Operation id</param>
        /// <param name="isAsync">Async operation</param>
        /// <param name="isAwaite">Awaite result</param>
        /// <param name="command">Command. Implementation ICommand</param>
        /// <returns></returns>
        T Create(Guid id, Guid operationId, bool isAsync, bool isAwaite, ICommand command);
    }
}

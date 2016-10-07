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
        /// <returns></returns>
        T Create(Guid id);

        /// <summary>
        /// Create Command package. ICommandPackage
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="type"></param>
        /// <returns></returns>
        T Create(Guid id, ECommandType type);

        /// <summary>
        /// Create short package. IShortPackage
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="command">Command. Implementation ICommand</param>
        /// <returns></returns>
        T Create(Guid id, ICommand command);

        /// <summary>
        /// Create full p[ackage with all atributes without name
        /// </summary>
        /// <typeparam name="TParam">Type of parametr</typeparam>
        /// <param name="id">Client id</param>
        /// <param name="command">Command. Implementation ICommand</param>
        /// <param name="param">Paramaters for command IParametr</param>
        /// <returns></returns>
        T Create<TParam>(Guid id, ICommand command, IParametr param);

        /// <summary>
        /// Create full p[ackage with all atributes
        /// </summary>
        /// <param name="name">Name of command, string</param>
        /// <typeparam name="TParam">Type of parametr</typeparam>
        /// <param name="id">Client id</param>
        /// <param name="command">Command. Implementation ICommand</param>
        /// <param name="param">Paramaters for command IParametr</param>
        /// <returns></returns>
        T Create<TParam>(Guid id, string name, ICommand command, IParametr param);
    }
}

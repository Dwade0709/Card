using System;
using Core.Command;
using Core.Interfaces;

namespace Core.Factories
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
        public static IPackageFactory<T> GetFactory<T>() where T : IFullPackage, IShortPackage, ICommandPackage
        {
            //if (typeof(T) == typeof(ICommandPackage))
            //    return new Factory<CommandPackage>() as IPackageFactory<T>;

            //if (typeof(T) == typeof(IShortPackage))
            //    return new Factory<ShortPackage>() as IPackageFactory<T>;

            return new Factory<FullPackage>() as IPackageFactory<T>;
        }

        /// <summary>
        /// Private generic factory class. Implementation for IPackageFactory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class Factory<T> : IPackageFactory<T> where T : IFullPackage, IShortPackage, ICommandPackage, new()
        {
            public T Create()
            {
                return new T();
            }

            public T Create(Guid id)
            {
                return new T { ClientId = id };
            }

            public T Create(Guid id, ECommandType type)
            {
                return new T { ClientId = id, Type = type };
            }

            public T Create(Guid id, ICommand command)
            {
                return new T { ClientId = id, Command = command };
            }

            public T Create<TParam>(Guid id, ICommand command, IParametr<TParam> param)
            {
                if(typeof(T) !=typeof(IFullPackage))
                    throw new ArgumentException($"Can't create {typeof(T)} by this method");
                return new T { ClientId = id, Command = command, Params = param as IParametr<object> };
            }

            public T Create<TParam>(Guid id, string name, ICommand command, IParametr<TParam> param)
            {
                if (typeof(T) != typeof(IFullPackage))
                    throw new ArgumentException($"Can't create {typeof(T)} by this method");
                return new T { ClientId = id, Command = command, Params = param as IParametr<object>, Name = name };
            }
        }

    }
}

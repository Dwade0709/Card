using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core
{
    public static class Factory
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //public static IFactory GetFactory<T>()
        //{
        //    return new Factory.FactoryGeneric<T>();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TObj"></typeparam>
        //private class FactoryGeneric<T> : IFactory where T : new()
        //{
        //    /// <summary>
        //    /// Implementation of this method must create T object
        //    /// </summary>
        //    /// <typeparam name="T">Type of object </typeparam>
        //    /// <returns></returns>
        //    public T Create<T>()
        //    {
        //        var type = typeof(T);

        //        if (type.IsInterface || type.IsAbstract)
        //            throw new ArgumentException("Can't implement interface or abstract class");
        //        return new T();
        //    }
        //}
    }
}

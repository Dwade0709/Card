using System;
using Core.Package;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for transport
    /// </summary>
    public interface ITransport<T>
    {
        T Client { get; set; }

        /// <summary>
        /// Recive data from client
        /// </summary>
        /// <returns></returns>
        object ReceiveData(out Type obj);

        /// <summary>
        /// Send data to adress
        /// </summary>
        /// <param name="pack">IPackage</param>
        void SendData(IPackage pack);

        /// <summary>
        /// Send data to adress
        /// </summary>
        /// <param name="pack">ICommandPackage </param>
        void SendData(ICommandPackage pack);

        /// <summary>
        /// Send data to adress
        /// </summary>
        /// <param name="pack">IShortPackage</param>
        void SendData(IShortPackage pack);
    }
}

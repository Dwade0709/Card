using System;
using Core.Interfaces;

namespace Client.Core
{
    /// <summary>
    /// Interface for client.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// GUID identifier client
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Version client
        /// </summary>
        Version ClientVersion { get; set; }

        /// <summary>
        /// Disconnect 
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="ip">IP adress</param>
        /// <param name="port">Port</param>
        bool Connect(string ip, int port);

        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="ip">IP adress</param>
        /// <param name="port">Port</param>
        void Reconnect(string ip, int port);

        /// <summary>
        /// Client listener connection
        /// </summary>
        void ClientListener(object stopError);

        /// <summary>
        /// Propertie with server info
        /// </summary>
        IServerInfoParams ServerInfo { get; set; }

        /// <summary>
        /// Get transport interface
        /// </summary>
        /// <typeparam name="T">Type protocol</typeparam>
        /// <returns></returns>
        ITransport<T> Transport<T>();
    }
}

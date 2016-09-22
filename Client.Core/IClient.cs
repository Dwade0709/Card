using System;
using Core;

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
        Guid Id { get; }

        /// <summary>
        /// Disconnect 
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="ip">IP adress</param>
        /// <param name="port">Port</param>
        void Connect(string ip, int port);

        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="ip">IP adress</param>
        /// <param name="port">Port</param>
        void Reconnect(string ip, int port);

        /// <summary>
        /// Send data to server
        /// </summary>
        void SendToServer(Package package);

        /// <summary>
        /// Client listener connection
        /// </summary>
        void ClientListener();
    }
}

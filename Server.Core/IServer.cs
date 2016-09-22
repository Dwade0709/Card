using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Client.Core;

namespace Server.Core
{
    /// <summary>
    /// Server base interface
    /// </summary>
    public abstract class AServer : Singleton<AServer>, IDisposable
    {
        private ServerAdress _adress;

        private IList<IClient> _clients;

        protected AServer()
        {
            LoggerService = ServiceContainer.Instance.Get<ILoggerService>();
        }

        /// <summary>
        /// Logger service
        /// </summary>
        public ILoggerService LoggerService { get; }

        /// <summary>
        /// List active clients
        /// </summary>
        public IList<IClient> Clients // все подключения
        {
            get
            {
                if (_clients == null)
                    _clients = new List<IClient>();
                return _clients;
            }
        }

        /// <summary>
        /// Add new client
        /// </summary>
        /// <param name="serverClientObject">Server client adapter to server and client</param>
        public void AddConnection(IServerClient<AServer, IClient> serverClientObject)
        {
            LoggerService.NLogger.Trace($"Connected new user {serverClientObject.Client.Id}");
            Clients.Add(serverClientObject.Client);
        }

        /// <summary>
        /// Remove user connection
        /// </summary>
        /// <param name="id">Client id</param>
        public void RemoveConnection(Guid id)
        {
            var client = Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                Clients.Remove(client);
                LoggerService.NLogger.Trace($"Disconect user {client.Id}");
            }
        }

        /// <summary>
        /// Server adress
        /// </summary>
        public virtual ServerAdress Adress
        {
            get
            {
                if (_adress == null)
                    _adress = new ServerAdress() { IpAdress = IPAddress.Any, Port = 0297 };
                return _adress;
            }
            set { _adress = value; }
        }

        /// <summary>
        /// Start
        /// </summary>
        public void StartServer(ServerAdress adress)
        {
            _adress = adress;
            StartServer();
        }

        /// <summary>
        /// Start
        /// </summary>
        public abstract void StartServer();

        /// <summary>
        /// Stop
        /// </summary>
        public abstract void StopServer();

        public void Dispose()
        {

        }
    }
}

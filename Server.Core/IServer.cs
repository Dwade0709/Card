using Core;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Server.Core
{
    /// <summary>
    /// Server base interface
    /// </summary>
    public abstract class AServer : Singleton<AServer>, IDisposable
    {
        private ILoggerService _loggerService;

        private ServerAdress _adress;

        private IList<ICoreServerClient> _clients;

        public AServer()
        {
            _loggerService = ServiceContainer.Instance.Get<ILoggerService>();
        }

        /// <summary>
        /// Logger service
        /// </summary>
        public ILoggerService LoggerService { get { return _loggerService; } }

        /// <summary>
        /// List active clients
        /// </summary>
        public IList<ICoreServerClient> Clients // все подключения
        {
            get
            {
                if (_clients == null)
                    _clients = new List<ICoreServerClient>();
                return _clients;
            }
        }

        /// <summary>
        /// Add new client
        /// </summary>
        /// <param name="clientObject">Client</param>
        public void AddConnection<TServer, TClient>(IServerClient<TServer, TClient> clientObject)
        {
            Clients.Add(clientObject);
        }

        /// <summary>
        /// Remove user connection
        /// </summary>
        /// <param name="id">Client id</param>
        public void RemoveConnection(string id)
        {
            var client = Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                Clients.Remove(client);
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

using Core;
using Core.Services;
using System;
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

        public AServer()
        {
            _loggerService = ServiceContainer.Instance.Get<ILoggerService>();
        }

        public ILoggerService LoggerService { get { return _loggerService; } }

        /// <summary>
        /// Server adress
        /// </summary>
        public virtual ServerAdress Adress
        {
            get
            {
                if (_adress == null)
                    _adress = new ServerAdress() { IpAdress = IPAddress.Any, Port = 3333 };
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

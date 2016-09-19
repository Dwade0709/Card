using Server.Core;
using System.Net.Sockets;
using System;
using Game.Core;
using Core;
using Game.Interfaces;
using Core.Services;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server.TCP
{
    internal class ServerClientTCP : IServerClient<ServerTCP, TcpClient>
    {
        private ILoggerService _loggerService;

        private IPlayerService _playerService;

        private TcpClient _client;

        private ServerTCP _server;

        private IPlayer _player;

        private Package _package;

        private string _id;

        internal ServerClientTCP(ServerTCP server, TcpClient client)
        {
            _loggerService = ServiceContainer.Instance.Get<ILoggerService>();
            _playerService = ServiceContainer.Instance.Get<IPlayerService>();
            _server = server;
            _client = client;
            _server.AddConnection(this);
        }

        public string Id
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_id))
                    _id = Guid.NewGuid().ToString();
                return _id;
            }
        }

        public TcpClient Client { get { return _client; } }

        public IPlayer Player { get { return _player; } }

        public ServerTCP Server { get { return _server; } }

        public static IServerClient<ServerTCP, TcpClient> CreateClient(ServerTCP server, TcpClient client)
        {
            return new ServerClientTCP(server, client);
        }

        public void GetData()
        {
            try
            {
                _package = SerialazerHelper.Deserialaze<Package>(Client.GetStream());
            }
            catch (Exception e)
            {
                _loggerService.NLogger.Error(e);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                _server.RemoveConnection(this.Id);
                LogOut();
            }
        }

        public void Login(string login, string password)
        {
            _player = _playerService.Login(login, password);
        }

        public void LogOut()
        {
            _package = null;
            if (_client != null)
                _client.Close();
        }

        public void Process()
        {
            while (true)
            {
                try
                {
                    GetData();
                }
                catch (Exception ex)
                {
                    _server.LoggerService.NLogger.Trace($"Logout {this.Id}");
                    _server.LoggerService.NLogger.Error(ex);
                    break;
                }
            }
        }
    }
}
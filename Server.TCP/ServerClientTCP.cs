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

        public TcpClient Client => _client;

        public IPlayer Player => _player;

        public ServerTCP Server => _server;

        public static IServerClient<ServerTCP, TcpClient> CreateClient(ServerTCP server, TcpClient client)
        {
            return new ServerClientTCP(server, client);
        }

        public void Login(string login, string password)
        {
            _player = _playerService.Login(login, password);
        }

        public void LogOut()
        {
            _package = null;
            _client?.Close();
        }

        public void GetData()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        var stream = Client.GetStream();
                        _package = SerialazerHelper.Deserialaze<Package>(stream);
                    }
                    catch (Exception ex)
                    {
                        _server.LoggerService.NLogger.Trace($"Logout {this.Id}");
                        _server.LoggerService.NLogger.Error(ex);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                _loggerService.NLogger.Error(e);
            }
            finally
            {
                _server.RemoveConnection(this.Id);
                LogOut();
            }
        }

        public void SetData(Package pack)
        {
            while (true)
            {
                var data = SerialazerHelper.Serialaze(pack);
                var stream = _client.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
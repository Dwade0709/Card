using Server.Core;
using System;
using Client.Core;
using Game.Core;
using Core;
using Game.Interfaces;
using Core.Services;
using Core.TCP;

namespace Server.TCP
{
    internal class ServerClientTcp : TransportTcp, IServerClient<ServerTcp, IClient>
    {
        private readonly ILoggerService _loggerService;

        private readonly IPlayerService _playerService;

        private readonly IClient _client;

        private readonly ServerTcp _server;

        private IPlayer _player;

        private Package _package;

        private string _id;

        internal ServerClientTcp(ServerTcp server, IClient client)
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

        public new IClient Client => _client;

        public IPlayer Player => _player;

        public ServerTcp Server => _server;

        public static IServerClient<ServerTcp, IClient> CreateClient(ServerTcp server, IClient client)
        {
            return new ServerClientTcp(server, client);
        }

        public void Login(string login, string password)
        {
            _player = _playerService.Login(login, password);
        }

        public void LogOut()
        {
            _package = null;
            _client.Disconnect();
        }

        //public void GetData()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            try
        //            {
        //                var stream = Client..GetStream();
        //                _package = SerialazerHelper.Deserialaze<Package>(stream);
        //            }
        //            catch (Exception ex)
        //            {
        //                _server.LoggerService.NLogger.Trace($"Logout {this.Id}");
        //                _server.LoggerService.NLogger.Error(ex);
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _loggerService.NLogger.Error(e);
        //    }
        //    finally
        //    {
        //        _server.RemoveConnection(Client.Id);
        //        LogOut();
        //    }
        //}

        //public void SetData(Package pack)
        //{
        //    while (true)
        //    {
        //        var data = SerialazerHelper.Serialaze(pack);
        //        var stream = _client.GetStream();
        //        stream.Write(data, 0, data.Length);
        //    }
        //}
    }
}
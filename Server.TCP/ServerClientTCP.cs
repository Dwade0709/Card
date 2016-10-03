using Server.Core;
using System;
using Client.Core;
using Core;
using Core.Services;
using Core.TCP;

namespace Server.TCP
{
    internal class ServerClientTcp : TransportTcp, IServerClient<ServerTcp, IClient>
    {
        //private readonly ILoggerService _loggerService;

        private readonly ServerTcp _server;

        private string _id;

        internal ServerClientTcp(ServerTcp server, IClient client)
        {
            //_loggerService = ServiceContainer.Instance.Get<ILoggerService>();
            _server = server;
            Client = client;
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

        public new IClient Client { get; }

        public ServerTcp Server => _server;

        public static IServerClient<ServerTcp, IClient> CreateClient(ServerTcp server, IClient client)
        {
            return new ServerClientTcp(server, client);
        }
    }
}
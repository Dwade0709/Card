using Core;
using Server.Core;

namespace Server.TCP
{
    public class ServerTcpFactory : ServerFactory
    {
        public override AServer CreateServer()
        {
            AServer server = new ServerTcp();
            return server;
        }

        public override AServer CreateServer(ServerAdress adress)
        {
            AServer server = new ServerTcp();
            ServiceContainer.Instance.SetAs<AServer>(server);
            server.Adress = adress;
            return server;
        }
    }
}

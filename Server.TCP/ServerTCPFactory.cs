using Server.Core;

namespace Server.TCP
{
    internal class ServerTcpFactory : ServerFactory
    {
        public override AServer CreateServer()
        {
            AServer server = new ServerTcp();
            return server;
        }

        public override AServer CreateServer(ServerAdress adress)
        {
            AServer server = new ServerTcp();
            server.Adress = adress;
            return server;
        }
    }
}

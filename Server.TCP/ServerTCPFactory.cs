using Server.Core;

namespace Server.TCP
{
    internal class ServerTCPFactory : ServerFactory
    {
        public override AServer CreateServer()
        {
            AServer server = new ServerTCP();
            return server;
        }

        public override AServer CreateServer(ServerAdress adress)
        {
            AServer server = new ServerTCP();
            server.Adress = adress;
            return server;
        }
    }
}

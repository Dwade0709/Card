using Server.Core;

namespace Server.TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerFactory factory = new ServerTCPFactory();
            var server = factory.CreateServer();

            server.StartServer();
        }
    }
}

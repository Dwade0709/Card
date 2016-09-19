using Server.Core;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Server.TCP
{
    class Program
    {
        static AServer server;// server object

        static Thread listenThread;// thread for server

        static void Main(string[] args)
        {

            try
            {

                ServerFactory factory = new ServerTCPFactory();
                server = factory.CreateServer(new ServerAdress { IpAdress = IPAddress.Parse(Server.Default.IP), Port = Server.Default.Port });

                listenThread = new Thread(new ThreadStart(server.StartServer));
                listenThread.Start(); // Start server thread

            }
            catch (Exception ex)
            {
                server.LoggerService.NLogger.Error(ex);
                server.StopServer();
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using Server.Core;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Server.TCP
{
    class Runner
    {
        static AServer _server;// server object

        static Thread _listenThread;// thread for server

        static void Main(string[] args)
        {

            try
            {

                ServerFactory factory = new ServerTcpFactory();
                _server = factory.CreateServer(new ServerAdress { IpAdress = IPAddress.Parse(Properties.Server.Default.IP), Port = Properties.Server.Default.Port });

                _listenThread = new Thread(_server.StartServer);
                _listenThread.Start(); // Start server thread

            }
            catch (Exception ex)
            {
                _server.LoggerService.NLogger.Error(ex);
                _server.StopServer();
                Console.WriteLine(ex.Message);
            }
        }
    }
}

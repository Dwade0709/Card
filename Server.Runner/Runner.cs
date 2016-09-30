using System;
using System.Net;
using System.Threading;
using Core;
using Server.Core;
using Server.TCP;

namespace Server.Runner
{
    class Runner
    {
        static AServer _server; // server object

        static Thread _listenThread; // thread for server

        static void Main(string[] args)
        {

            try
            {
                ServerFactory factory = new ServerTcpFactory();
                _server =
                    factory.CreateServer(new ServerAdress
                    {
                        IpAdress = IPAddress.Parse(Properties.Server.Default.IP),
                        Port = Properties.Server.Default.Port
                    });

                _listenThread = new Thread(_server.StartServer);
                _listenThread.Start(); // Start server thread
                ServiceContainer.Instance.Get<ServerInfo>().ServerAdress = $"{Properties.Server.Default.IP} {Properties.Server.Default.Port}";
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

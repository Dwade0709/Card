using System;
using System.IO;
using System.Net;
using System.Threading;
using Core;
using Microsoft.Extensions.Configuration;
using Server.Core;
using Server.TCP;

namespace Server.Runer
{
    class Runner
    {
        public static IConfigurationRoot Configuration { get; set; }

        static AServer _server; // server object

        static Thread _listenThread; // thread for server

        static void Main(string[] args)
        {

            try
            {
                //.net Core settings initialization
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("project.json");
                Configuration = builder.Build();

                ServerFactory factory = new ServerTcpFactory();
                _server =
                    factory.CreateServer(new ServerAdress
                    {
                        IpAdress = IPAddress.Parse(Configuration["settings:serverIp"]),
                        Port = Convert.ToInt32(Configuration["settings:serverPort"])
                    });

                _listenThread = new Thread(_server.StartServer);
                _listenThread.Start(); // Start server thread
            }
            catch (Exception ex)
            {
                _server.LoggerService.Error(ex);
                _server.StopServer();
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using Client.Core;
using Core;
using System;
using System.Net.Sockets;
using System.Threading;
using Core.Command;
using Core.Interfaces;
using Core.Package;
using Core.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Client.TCP
{
    class Runner
    {
        public static IConfigurationRoot Configuration { get; set; }
        private static IClient _client;
        static void Main(string[] args)
        {
            try
            {
                ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
                _client = new ClientTcp();

                ServiceContainer.Instance.SetAs<IClient>(_client);

                //.net Core settings initialization
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("project.json");
                Configuration = builder.Build();


                if (_client.Connect(Configuration["settings:serverIp"], Convert.ToInt32(Configuration["settings:serverPort"])))
                {
                    Thread clientThread = new Thread(_client.ClientListener);
                    clientThread.Start();
                }
              
                while (true)
                {
                    //  var package = PackageFactory.GetFactory<IShortPackage>().Create(_client.Id, new ConsoleCommand(Console.ReadLine()));

                    //                    _client.Transport<TcpClient>().SendData(package);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _client?.Disconnect();
            }


        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            _client.Transport<TcpClient>().SendData(PackageFactory.GetFactory<IPackage>().Create(_client.Id, ECommandType.Disconnect));
            _client.Disconnect();
            Console.WriteLine("exit");
        }
    }
}

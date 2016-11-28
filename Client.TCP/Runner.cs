using Core;
using System;
using System.Net.Sockets;
using System.Threading;
using Core.Command;
using Core.Package;
using Core.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using Client.Core;

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
                    clientThread.Start(true);
                }

                #region  [ Section authorize ]

                Console.WriteLine("Login: ");
                var name = Console.ReadLine();
                Console.WriteLine("Pass: ");
                var pass = Console.ReadLine();
                var param = DynamicParam.CreateDynamic();
                param.SetValue("userName", name);
                param.SetValue("passHash", pass);

                var command = PackageFactory.GetFactory<ICommandPackage>().Create(_client.Id, ECommandType.UserLogin);
                command.Params = param;
                _client.Transport<TcpClient>().SendData(command);

                #endregion

                while (true)
                    if (Console.ReadLine() == "exit")
                        break;
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

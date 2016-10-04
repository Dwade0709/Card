using Client.Core;
using Core;
using System;
using System.Net.Sockets;
using Core.Command;
using Core.Interfaces;
using Core.Package;
using Core.Services;

namespace Client.TCP
{
    class Runner
    {
        private static IClient _client;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            try
            {
                ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
                _client = new ClientTcp();
                ServiceContainer.Instance.SetAs<IClient>(_client);
                _client.Connect(Properties.Client.Default.ServerIP, Properties.Client.Default.ServerPort);
                while (true)
                {
                    var package = PackageFactory.GetFactory<IShortPackage>().Create(_client.Id, new ConsoleCommand(Console.ReadLine()));

                    _client.Transport<TcpClient>().SendData(package);
                    Console.ReadKey();
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

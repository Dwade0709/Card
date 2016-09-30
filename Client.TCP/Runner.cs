using Client.Core;
using Core;
using System;
using Core.Services;
using static Core.Package;

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
                    var param = Console.ReadLine();
                    var pack = new Package
                    {
                        Name = param,
                        Command = new ConsoleCommand(param)
                    };
                    _client.SendToServer(pack);
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
            _client.Disconnect();
            Console.WriteLine("exit");
        }
    }


}

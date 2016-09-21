using Client.Core;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Services;

namespace Client.TCP
{
    class Program
    {
        private static IClient _client;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            try
            {
                ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");
                Console.ReadKey();
                _client = new ClientTcp();
                _client.Connect(Client.Default.ServerIP, Client.Default.ServerPort);


                ((ITransport<TcpClient>)_client).SendData(new Package() { Name = Console.ReadLine() });

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

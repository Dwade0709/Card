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
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            try
            {
                ServiceContainer.Instance.SetAs<ILoggerService>("Core.Services.LoggerService");

                _client = new ClientTcp();
                _client.Connect(Client.Default.ServerIP, Client.Default.ServerPort);
                var clientt = new Clientt();
                clientt.Input(_client);
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

    [Serializable]
    class Clientt
    {
        public void Input(IClient client)
        {

            while (true)
            {
                var param = Console.ReadLine();
                var pack = new Package
                {
                    Name = param,
                    Action = () => { WriteParam(param); }
                };
                client.SendToServer(pack);
            }
        }


        public void WriteParam(string str)
        {
            Console.WriteLine(str);
        }
    }
}

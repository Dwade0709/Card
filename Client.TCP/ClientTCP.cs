using System;
using Client.Core;
using Core;
using System.Net.Sockets;

namespace Client.TCP
{
    internal class ClientTCP : IClient
    {
        //private ILoggerService _loggerService;

        private TcpClient _client;

        internal ClientTCP(TcpClient client)
        {
            _client = client;

        }


        public Package ReceiveData()
        {
            while (true)
            {
                try
                {
                    return SerialazerHelper.Deserialaze<Package>(_client.GetStream());
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        public void SendData(Package pack)
        {
            while (true)
            {
                var data = SerialazerHelper.Serialaze(pack);
                var stream = _client.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }

        public void Disconnect()
        {
            _client?.Close();
        }


        public void Receive()
        {
            //TODO Только для теста
            while (true)
            {
                var package = ReceiveData();
                Console.WriteLine(package.Name);
            }
        }
    }
}

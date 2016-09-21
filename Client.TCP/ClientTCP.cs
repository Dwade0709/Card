using Client.Core;
using System.Net.Sockets;
using System.Threading;
using Core.TCP;
using System;
using Core;

namespace Client.TCP
{
    internal class ClientTcp : TransportTcp, IClient
    {
        private Guid _id;

        private int i = 0;

        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();
                return _id;
            }
        }

        public void Disconnect()
        {
            Client?.Close();
        }

        public void Connect()
        {
            Thread receiveThread = new Thread(new ThreadStart(ClientListener));
            receiveThread.Start();
        }

        public void Connect(string ip, int port)
        {

            try
            {
                var tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
                Logger.NLogger.Trace($"Client {Id} was connected");
            }
            catch (Exception ex)
            {
                Logger.NLogger.Error(ex);
                Logger.NLogger.Trace(ex.Message);
                i++;
                if (i < 5)
                    Reconnect(ip, port);
            }
        }

        private void ClientListener()
        {
            while (true)
            {
                var package = ReceiveData();
                package?.Action?.Invoke();
            }
        }

        public void Reconnect(string ip, int port)
        {
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
            Logger.NLogger.Trace("Try reconecting...");
            Connect(ip, port);
        }

        public void SendToServer(Package package)
        {
            package.ClientId = Id;
            SendData(package);
        }
    }
}

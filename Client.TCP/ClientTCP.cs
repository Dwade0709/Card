using Client.Core;
using System.Net.Sockets;
using System.Threading;
using Core.TCP;
using System;
using System.Reflection;
using Core;
using Core.Command;
using Core.Interfaces;

namespace Client.TCP
{
    internal class ClientTcp : TransportTcp, IClient, ITransport<TcpClient>
    {
        private Guid _id;

        private int _i;

        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                    _id = Guid.NewGuid();
                return _id;
            }
            set { _id = value; }
        }

        public Version ClientVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        public void Disconnect()
        {
            Client?.Close();
        }

        public void Connect()
        {
            Thread receiveThread = new Thread(ClientListener);
            receiveThread.Start();
        }

        public void Connect(string ip, int port)
        {

            try
            {
                var tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);
                Client = tcpClient;
                Logger.NLogger.Trace($"Client {Id} was connected");
            }
            catch (Exception ex)
            {
                Logger.NLogger.Error(ex);
                Logger.NLogger.Trace(ex.Message);
                _i++;
                if (_i < 5)
                    Reconnect(ip, port);
            }
        }

        public void ClientListener()
        {
            while (true)
            {
                var package = ReceiveData();
                if (package.Type == null)
                {
                    var command = CommandFactory.GetFactory<ECommandType>().Create<ICommand>();
                    command.Execute();
                }
                else
                    package?.Command?.Execute();
            }
        }

        public IServerInfoParams ServerInfo { get; set; }

        public void Reconnect(string ip, int port)
        {
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
            Logger.NLogger.Trace("Try reconecting...");
            Connect(ip, port);
        }

        public void SendToServer(Package package)
        {
            package.ClientId = Id;
            base.SendData(package);
        }
    }
}

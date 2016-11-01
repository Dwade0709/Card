using Client.Core;
using System.Net.Sockets;
using Core.TCP;
using System;
using System.Reflection;
using Core.Interfaces;
using Core.Package;
using System.Threading;

namespace Client.TCP
{
    public class ClientTcp : TransportTcp, IClient
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
            Client?.Dispose();
        }

        public void Connect()
        {
            Thread receiveThread = new Thread(ClientListener);
            receiveThread.Start();
        }

        public async void Connect(string ip, int port)
        {

            try
            {
                var tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(ip, port);
                Client = tcpClient;
                Logger.Trace($"Client {Id} was connected");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Trace(ex.Message);
                _i++;
                if (_i < 5)
                    Reconnect(ip, port);
            }
        }

        public void ClientListener()
        {
            while (true)
            {
                Type obj;
                var package = ReceiveData(out obj);
                if (package == null) continue;
                if (obj == typeof(IPackage))
                    ((IPackage)package).Command?.Execute();
                if (obj == typeof(IShortPackage))
                    ((IShortPackage)package).Command?.Execute();
                if (obj == typeof(ICommandPackage))
                {

                    //var command = CommandFactory<ICommand>.GetFactory().Create<ICommand>();
                    //command.Execute();
                }
            }
        }

        public IServerInfoParams ServerInfo { get; set; }

        public ITransport<TCpClient> Transport<TCpClient>()
        {
            return (ITransport<TCpClient>)this;
        }

        public void Reconnect(string ip, int port)
        {
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
            Logger.Trace("Try reconecting...");
            Connect(ip, port);
        }
    }
}

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

        public bool Connect(string ip, int port)
        {

            try
            {
                var tcpClient = new TcpClient();
                tcpClient.ConnectAsync(ip, port);
                Client = tcpClient;
                if (tcpClient.Connected)
                {
                    Logger.Trace($"Client {Id} was connected");
                    return true;
                }
                Logger.Trace($"Server unavaliable");
                _i++;
                if (_i < 5)
                    Reconnect(ip, port);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Trace(ex.Message);
                return false;
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
            Logger.Trace("Try reconecting...");
            Thread.Sleep(new TimeSpan(0, 0, 0, 5));
            Connect(ip, port);
        }
    }
}

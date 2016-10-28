using System;
using Server.Core;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using Client.Core;
using Core;
using Core.Interfaces;
using Core.Package;
using Core.Command.Command.Param;

namespace Server.TCP
{
    internal class ServerTcp : AServer
    {
        private TcpListener _listener;

        public override void StartServer()
        {
            try
            {
                _listener = new TcpListener(Adress.IpAdress, Adress.Port);
                LoggerService.NLogger.Trace("Starting TCP server");
                _listener.Start();
                LoggerService.NLogger.Trace($"Start TCP server on {Adress.IpAdress} port {Adress.Port}");
                LoggerService.NLogger.Trace($"Version:{Assembly.GetExecutingAssembly().GetName().Version}");
                while (true)
                {
                    try
                    {
                        var client = _listener.AcceptTcpClient();
                        {
                            var tcpClient = ServiceContainer.Instance.Get<IClient>();
                            ((ITransport<TcpClient>)tcpClient).Client = client;
                            tcpClient.Id = Guid.NewGuid();
                            IServerClient<AServer, IClient> clientObject = ServerClientTcp.CreateClient(this, tcpClient);

                            //Command for presentation 
                            var command = ServiceContainer.Instance.Get<ICommandManager>().GetCommand("PresentServerCommand");
                            var param = ServiceContainer.Instance.Get<ServerInfoParam>();
                            param.ClientGuid = tcpClient.Id;
                            command.SetParametr(param);
                            var package = PackageFactory.GetFactory<IShortPackage>().Create(clientObject.Client.Id, command);

                            ((ITransport<TcpClient>)tcpClient).SendData(package);

                            Thread clientThread = new Thread(clientObject.Client.ClientListener);
                            clientThread.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerService.NLogger.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerService.NLogger.Error(ex);
            }
        }

        public override void StopServer()
        {
            foreach (var client in Clients)
            {
                client.Disconnect();

            }
            if (_listener != null)
            {
                _listener.Stop();
                LoggerService.NLogger.Trace("Stop TCP server");
                Thread.Sleep(10000);
            }
        }
    }
}

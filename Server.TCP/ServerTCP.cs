using System;
using Server.Core;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;
using Core;
using System.Reflection;

namespace Server.TCP
{
    internal class ServerTCP : AServer
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
                    var client = _listener.AcceptTcpClient();
                    if (client != null)
                    {
                        IServerClient<ServerTCP, TcpClient> clientObject = ServerClientTCP.CreateClient(this, client);
                        Thread clientThread = new Thread(new ThreadStart(clientObject.GetData));
                        clientThread.Start();
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
                client.LogOut();

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

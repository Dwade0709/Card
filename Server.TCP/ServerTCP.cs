using System;
using Server.Core;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

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
                _LoggerService.NLogger.Trace("Starting TCP server");
                _listener.Start();
                _LoggerService.NLogger.Trace($"Start TCP server on {Adress.IpAdress} port {Adress.Port}");
                while (true)
                {
                    //TODO Multithreading

                    var client = _listener.AcceptTcpClient();
                    if (client != null)
                    {
                        Console.WriteLine("Client logined");
                        using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.Unicode))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                _LoggerService.NLogger.ErrorException("Server starting ERROR", ex);
            }
        }

        public override void StopServer()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _LoggerService.NLogger.Trace("Stop TCP server");
                Thread.Sleep(10000);
            }
        }
    }
}

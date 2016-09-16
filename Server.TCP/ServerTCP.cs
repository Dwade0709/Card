using Server.Core;
using System.Net.Sockets;

namespace Server.TCP
{
    internal class ServerTCP : AServer
    {
        private TcpListener _listener;

        public override void StartServer()
        {
            _listener = new TcpListener(Adress.IpAdress, Adress.Port);
            //LoggerService.Trace("Start TCP server");
            while (true)
            {
                _listener.AcceptTcpClient();
            }
        }

        public override void StopServer()
        {
            if (_listener != null)
                _listener.Stop();
        }
    }
}

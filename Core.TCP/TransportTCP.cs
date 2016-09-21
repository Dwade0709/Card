using System.Net.Sockets;
using Core.Services;

namespace Core.TCP
{
    /// <summary>
    /// TCP realization transport layer
    /// </summary>
    public abstract class TransportTcp : ITransport<TcpClient>
    {
        protected readonly ILoggerService Logger;

        protected TransportTcp()
        {
            Logger = ServiceContainer.Instance.Get<ILoggerService>();
        }

        public TcpClient Client { get; set; }

        public Package ReceiveData()
        {
            while (true)
            {
                try
                {
                    if (Client != null) return SerialazerHelper.Deserialaze<Package>(Client.GetStream());
                }
                catch
                {
                    Logger.NLogger.Trace("Connection close");

                    Client?.Close();
                }
            }
        }

        public void SendData(Package pack)
        {
            while (true)
            {
                var data = SerialazerHelper.Serialaze(pack);
                var stream = Client.GetStream();
                stream.Write(data, 0, data.Length);
            }
        }


    }
}

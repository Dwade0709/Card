using System.Net.Sockets;
using Core.Interfaces;
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
            try
            {
                var stream = Client.GetStream();
                if (stream.DataAvailable)
                    return SerialazerHelper.Deserialaze<Package>(stream);
                return null;
            }
            catch (System.Exception ex)
            {
                Logger.NLogger.Error(ex);
                Logger.NLogger.Trace("Connection close");
                Client?.Close();
            }
            return null;
        }

        public void SendData(Package pack)
        {
            var data = SerialazerHelper.Serialaze(pack);
            var stream = Client.GetStream();
            stream.Write(data, 0, data.Length);
        }
    }
}

using Core;

namespace Client.Core
{
    public interface IClient
    {
        Package ReceiveData();

        void SendData(Package pack);

        void Disconnect();

        void Receive();
    }
}

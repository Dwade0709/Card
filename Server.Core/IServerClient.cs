using Core;
using Game.Core;

namespace Server.Core
{
    public interface IServerClient<Tserver, TClient> : ICoreServerClient
    {
        Tserver Server { get; }

        TClient Client { get; }

        void GetData();

        void SetData(Package pack);
    }
}

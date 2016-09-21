using Core;
using Game.Core;

namespace Server.Core
{
    public interface IServerClient<Tserver, TClient> 
    {
        Tserver Server { get; }

        TClient Client { get; }
    }
}

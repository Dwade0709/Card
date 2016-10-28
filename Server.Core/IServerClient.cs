namespace Server.Core
{
    public interface IServerClient<out Tserver, out TClient>
    {
        Tserver Server { get; }

        TClient Client { get; }
    }
}

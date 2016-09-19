using Game.Core;

namespace Server.Core
{
    public interface ICoreServerClient
    {
        string Id { get; }

        void Login(string login, string password);

        void LogOut();

        IPlayer Player { get; }
    }
}

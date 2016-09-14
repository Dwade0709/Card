using Core;
using Core.Services;
using Game.Interfaces;

namespace Card.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Core.Initialazer.Instance.InitServices();
            var logger = ServiceContainer.Instance.Get<ILoggerService>();
            var playerservice = ServiceContainer.Instance.Get<IPlayerService>();
            var player = playerservice.CreatePlayer(null);
            System.Console.ReadKey();
        }
    }
}

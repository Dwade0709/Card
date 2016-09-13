using Core;
using Core.Services;

namespace Card.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Core.Initialazer.Instance.InitServices();
            var logger = ServiceContainer.Instance.Get<ILoggerService>(); 
            System.Console.ReadKey();
        }
    }
}

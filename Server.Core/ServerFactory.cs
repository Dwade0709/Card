/// <summary>
/// Server factory
/// </summary>
namespace Server.Core
{
    public abstract class ServerFactory
    {
        public ServerFactory()
        {
            Initialazer.Instance.InitServices();
        }

        /// <summary>
        /// Create object server
        /// </summary>
        /// <returns></returns>
        public abstract AServer CreateServer();

        /// <summary>
        /// Create object server
        /// </summary>
        /// <param name="adress">Server adress</param>
        /// <returns></returns>
        public abstract AServer CreateServer(ServerAdress adress);
    }
}

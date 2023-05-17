namespace Server.Core
{
    /// <summary>
    /// Server factory
    /// </summary>
    public abstract class ServerFactory
    {
        protected ServerFactory()
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

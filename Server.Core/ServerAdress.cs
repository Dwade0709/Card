using System.Net;

namespace Server.Core
{
    /// <summary>
    /// Server adress model
    /// </summary>
    public class ServerAdress
    {
        /// <summary>
        /// Sheme
        /// </summary>
        public string Sheme { get; set; }

        /// <summary>
        /// Server name (DNS)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// IP Adress
        /// </summary>
        public IPAddress IpAdress { get; set; }
    }
}

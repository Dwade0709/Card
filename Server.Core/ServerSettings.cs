namespace Server.Core
{
    /// <summary>
    /// Base server settings
    /// </summary>
    public class ServerSettings
    {
        /// <summary>
        /// Server version Server.Core.Dll
        /// </summary>
        public string ServerVersion { get; set; }

        /// <summary>
        /// Server port
        /// </summary>
        public string ServerPort { get; set; }

        /// <summary>
        /// Server ip
        /// </summary>
        public string ServerIp { get; set; }

        /// <summary>
        /// Connection string to accounts db
        /// </summary>
        public string AccountsDbConnection { get; set; }

        /// <summary>
        /// Connection string to server setting db
        /// </summary>
        public string ServerSettingDbConnection { get; set; }

        /// <summary>
        /// Chat enable
        /// </summary>
        public bool IsChatEnable { get; set; }
    }
}

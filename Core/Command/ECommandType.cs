namespace Core.Command
{
    public enum ECommandType
    {
        /// <summary>
        /// Command to disconnect
        /// </summary>
        Disconnect,

        /// <summary>
        /// Command to login
        /// </summary>
        UserLogin,

        /// <summary>
        /// New client was connected
        /// </summary>
        ConnectionNewClient
    }
}
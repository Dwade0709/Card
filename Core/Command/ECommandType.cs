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
        ConnectionNewClient,

        /// <summary>
        /// Connection was sucsess. Callback for set hardware key if need
        /// </summary>
        ConnectionOk
    }
}
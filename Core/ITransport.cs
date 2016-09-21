namespace Core
{
    /// <summary>
    /// Interface for transport
    /// </summary>
    public interface ITransport<T>
    {
        T Client { get; set; }

        /// <summary>
        /// Recive data from client
        /// </summary>
        /// <returns></returns>
        Package ReceiveData();

        /// <summary>
        /// Send data to adress
        /// </summary>
        /// <param name="pack"></param>
        void SendData(Package pack);
    }
}

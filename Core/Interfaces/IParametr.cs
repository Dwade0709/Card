namespace Core.Interfaces
{
    /// <summary>
    /// Interface parametr command
    /// </summary>
    public interface IParametr<T>
    {
        /// <summary>
        /// Factory method for creation parametrs
        /// </summary>
        /// <returns></returns>
        IParametr<T> CreateParameter();


        /// <summary>
        /// Instance parametr
        /// </summary>
        T Instance { get; }
    }
}

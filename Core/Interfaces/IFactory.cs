namespace Core.Interfaces
{
    /// <summary>
    /// Interface for base factory. Had method for creation object
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Implementation of this method must create T object
        /// </summary>
        /// <typeparam name="T">Type of object </typeparam>
        /// <returns></returns>
        T Create<T>();
    }
}

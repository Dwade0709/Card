namespace Game.Core
{
    /// <summary>
    /// Base interface for creation core object
    /// </summary>
    public interface ICoreFactory
    {
        T Create<T>();
    }
}

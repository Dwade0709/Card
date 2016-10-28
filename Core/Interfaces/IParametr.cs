namespace Core.Interfaces
{
    /// <summary>
    /// Interface parametr command
    /// </summary>
    public interface IParametr
    {
        T GetValue<T>(string key);
    }
}

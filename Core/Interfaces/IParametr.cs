using ProtoBuf;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface parametr command
    /// </summary>
    [ProtoContract]
    public interface IParametr
    {
        T GetValue<T>(string key);

        string GetValue(string key);
    }
}

using Core.Interfaces;

namespace Client.Core
{
    /// <summary>
    /// Server info interface
    /// </summary>
    public interface IServerInfoParams : IParametr
    {
        string ServerVersion { get; }

        string ServerAdress { get; }
    }
}

using Core.Interfaces;

namespace Client.Core
{
    /// <summary>
    /// Server info interface
    /// </summary>
    public interface IServerInfoParams : IParametr<IServerInfoParams>
    {
        string ServerVersion { get; }

        string ServerAdress { get; }
    }
}

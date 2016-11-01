using Core.Interfaces;

namespace Client.Core
{
    /// <summary>
    /// Server info interface
    /// </summary>
    [ProtoBuf.ProtoContract]
    public interface IServerInfoParams : IParametr
    {
        [ProtoBuf.ProtoMember(1)]
        string ServerVersion { get; }

        [ProtoBuf.ProtoMember(2)]
        string ServerAdress { get; }
    }
}

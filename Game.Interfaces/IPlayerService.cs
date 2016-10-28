using Game.Core;

namespace Game.Interfaces
{
    /// <summary>
    /// Player service interface
    /// </summary>
    public interface IPlayerService
    {
        IPlayer CreatePlayer(IUser user);

        void ChangeState(IPlayer player);
    }
}

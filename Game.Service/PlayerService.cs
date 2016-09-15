using Game.Core;
using Game.Interfaces;

namespace Game.Service
{
    /// <summary>
    /// Player service player operation
    /// </summary>
    internal class PlayerService : IPlayerService
    {
        public void ChangeState(IPlayer player)
        {
            player.State.Handle(player);
        }

        public IPlayer CreatePlayer(IUser user)
        {
            IPlayer obj = CoreFactory.GetFactory<IPlayer>().Create<IPlayer>();
            obj.Name = user.Name;
            obj.Login = user.Login;
            obj.UserState = user.UserState;
            return obj;
        }
    }
}

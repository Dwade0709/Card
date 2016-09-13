using Game.Core;
using Game.Interfaces;

namespace Game.Service
{
    /// <summary>
    /// 
    /// </summary>
    internal class PlayerService : IPlayerService
    {
        public void ChangeState(IPlayer player)
        {
            player.State.Handle(player);
        }

        public IPlayer CreatePlayer(IUser user)
        {
            var player = new Player(new WaitingState());
            player.Login = user.Login;
            player.Name = user.Name;
            return player;
        }
    }
}

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
            var obj = CoreFactory<IPlayer>.GetFactory().Create();
            obj.Name = user.Name;
            obj.Login = user.Login;
            return CoreFactory<IPlayer>.GetFactory().Create();
        }
    }
}

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
            IPlayer obj = CoreFactory.GetFactory<IPlayer>().Create<IPlayer>();
            obj.Name = "test";
            obj.Login = "testLogin";
            return obj;
        }
    }
}

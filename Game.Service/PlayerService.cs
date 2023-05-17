using Game.Core;
using Game.Interfaces;
using Core;

namespace Game.Service
{
    /// <summary>
    /// Player service player operation
    /// </summary>
    internal class PlayerService : IPlayerService
    {
        private IUserService _userService;

        public void ChangeState(IPlayer player)
        {
            player.State.Handle(player);
            _userService = ServiceContainer.Instance.Get<IUserService>();
        }

        public IPlayer CreatePlayer(IUser user)
        {
            IPlayer obj = CoreFactory.GetFactory<IPlayer>().Create<IPlayer>();
            obj.Name = user.Name;
            obj.Login = user.Login;
            obj.UserState = user.UserState;
            return obj;
        }

        public IPlayer Login(string login, string password, params string[] args)
        {
            return CreatePlayer(_userService.CreateUser(login,login));
        }
    }
}

using Game.Core;
using Game.Interfaces;

namespace Game.Service
{
    internal class UserService : IUserService
    {
        public void ChangeState(IUser user)
        {
            user.UserState.Handle(user);
        }

        public IUser CreateUser(string name, string login)
        {
            var user = CoreFactory.GetFactory<IUser>().Create<IUser>();
            user.Name = name;
            user.Login = login;
            return user;
        }
    }
}

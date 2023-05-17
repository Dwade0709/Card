using Game.Core;

namespace Game.Interfaces
{
    /// <summary>
    /// Service for work with user
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Change ctate online/offline
        /// </summary>
        /// <param name="user">IUser </param>
        void ChangeState(IUser user);

        /// <summary>
        /// Creating user
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="login">User login</param>
        /// <returns></returns>
        IUser CreateUser(string name, string login);
    }
}

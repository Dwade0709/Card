using Core.Command;
using Core.Interfaces;

namespace Server.Core.Command.Param
{
    public class UserLoginParam : AParametr<UserLoginParam>, IParametr
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

using Core.Interfaces;

namespace Core.Command.Command.Param
{
    public class UserLoginParam : AParametr<UserLoginParam>, IParametr
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

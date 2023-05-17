using Core;
using Core.Command;
using Server.Service;

namespace Server.Core.Command.Command
{
    internal class UserLoginCommand : ACommand
    {
        public override void Execute()
        {
            ServiceContainer.Instance.Get<IUserService>().Login(Parametrs.GetValue<string>("userName"), Parametrs.GetValue<string>("passHash"));
        }
    }
}

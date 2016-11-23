using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Command.Command
{
    internal class UserLoginCommand : ACommand
    {
        public override void Execute()
        {
            var userName = Parametrs.GetValue<string>("UserName");
            var passHash = Parametrs.GetValue<string>("Password");


        }
    }
}

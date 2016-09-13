using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Core
{
    public interface IPlayer
    {
        string Name { get; set; }

        IUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Core
{
    internal class GameCardFactory : CardFactory
    {
        public override Card CreateCard()
        {
            return new GameCard();
        }
    }
}

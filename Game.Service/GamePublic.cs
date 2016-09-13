using System;
using Card.Core;
using Game.Core;
using Game.Interfaces;

namespace Game.Service
{
    internal class GamePublic : IGamePublic
    {
        public ICardDeck GameDeck
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IObservable<IPlayer> Players
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

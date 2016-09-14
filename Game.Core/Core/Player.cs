using System;
using Card.Core;
using Game.Core.Core;

namespace Game.Core
{
    /// <summary>
    /// Game player
    /// </summary>
    internal class Player : User, IPlayer
    {
        public Player()
        {
            State = new WaitingState();
        }

        internal Player(APlayerState state)
        {
            State = state;
        }

        public APlayerState State { get; set; }

        public ICard GameRole { get; set; }

        public ICardDeck PlayerDeck { get; set; }

        public ICard Role { get; set; }

    }
}

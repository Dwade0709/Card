using Card.Core;

namespace Game.Core
{
    /// <summary>
    /// Game player
    /// </summary>
    internal class Player : IPlayer
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

        public string Login { get; set; }

        public string Name { get; set; }

        public ICardDeck PlayerDeck { get; set; }

        public ICard Role { get; set; }

        public AUserState UserState { get; set; }
        
    }
}

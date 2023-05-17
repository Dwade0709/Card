using Card.Core;

namespace Game.Core
{
    public interface IPlayer : IUser
    {
        APlayerState State { get; set; }

        ICard Role { get; set; }

        ICard GameRole { get; set; }

        ICardDeck PlayerDeck { get; set; }
    }
}

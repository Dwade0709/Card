using Card.Core;

namespace Game.Core
{
    public interface IPlayer
    {
        APlayerState State { get; set; }

        ICard Role { get; set; }

        ICard GameRole { get; set; }

        ICardDeck PlayerDeck { get; set; }

        //IPlayer Create(APlayerState state,IUser user);
    }
}

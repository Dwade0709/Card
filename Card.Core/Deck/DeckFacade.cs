using Card.Core.Enum;

namespace Card.Core
{
    public class DeckFacade
    {
        public static ICardDeck CreateDeck(CardDeckEnum type)
        {
            DeckBuilder builder = new NullDeckBuilder();

            switch (type)
            {
                case CardDeckEnum.GAME_CARD_DECK:
                    builder = new GameCardDeckBuilder();
                    builder.CreateCards(CardFactory.GetFactory(CardTypeE.GameCard));
                    break;
                case CardDeckEnum.PLAYING_DECK:
                    builder = new PlayingCardDeckBuilder();
                    builder.CreateCards(CardFactory.GetFactory(CardTypeE.PlayingCard));
                    break;
                case CardDeckEnum.ROLE_DECK:
                    builder = new GameCardDeckBuilder();
                    builder.CreateCards(CardFactory.GetFactory(CardTypeE.RoleCard));
                    break;
            }
            return builder.CardDeck;
        }
    }
}

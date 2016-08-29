using Card.Core;

namespace Card.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardGame cardgame = new CardGame();
            cardgame.Init();

            var cardsRole = cardgame.PassCards(Core.Enum.CardDeckEnum.ROLE_DECK);
            var cardsGame = cardgame.PassCards(Core.Enum.CardDeckEnum.GAME_CARD_DECK);
            var cardsPlaying = cardgame.PassCards(Core.Enum.CardDeckEnum.PLAYING_DECK);
        }
    }
}

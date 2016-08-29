using Card.Core;
using Card.Core.Enum;

namespace Card.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardGame cardgame = new CardGame();
            cardgame.Init();


            foreach (var cardsDeck in cardgame.CardsDecks)
            {
                System.Console.WriteLine($"---------------------------------------------");
                System.Console.WriteLine($"{cardsDeck.Name}");
                System.Console.WriteLine($"---------------------------------------------");

                if (cardsDeck.DeckType == CardDeckEnum.ROLE_DECK)
                    System.Console.WriteLine($"{cardsDeck.GetRandomCard(true).Name}");
                if (cardsDeck.DeckType == CardDeckEnum.GAME_CARD_DECK)
                    System.Console.WriteLine($"{cardsDeck.GetRandomCard(true).Name}");
                if (cardsDeck.DeckType == CardDeckEnum.PLAYING_DECK)
                    for (int i = 0; i < 6; i++)
                        System.Console.WriteLine($"{cardsDeck.GetRandomCard(true).Name}");
                System.Console.WriteLine($"---------------------------------------------");

            }
            System.Console.ReadKey();
        }
    }
}

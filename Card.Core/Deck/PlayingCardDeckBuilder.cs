using System.Xml.XPath;

// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class PlayingCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(ICardFactory factory)
        {
            Creator(ConfigDocument.XPathSelectElements("//playing/*"), factory);
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.PLAYING_DECK;
        }

        public override void SetName()
        {
            CardDeck.Name = Enum.CardDeckEnum.PLAYING_DECK.ToString();
        }
    }
}

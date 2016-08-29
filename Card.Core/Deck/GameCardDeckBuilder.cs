using System.Xml.XPath;

// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class GameCardDeckBuilder : DeckBuilder
    {
        public override void CreateCards(CardFactory factory)
        {
            Creator(ConfigDocument.XPathSelectElements("//game/*"), factory);
        }

        public override void SetType()
        {
            CardDeck.DeckType = Enum.CardDeckEnum.GAME_CARD_DECK;
        }

        public override void SetName()
        {
            CardDeck.Name = Enum.CardDeckEnum.GAME_CARD_DECK.ToString();
        }
    }
}

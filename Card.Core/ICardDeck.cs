using Card.Core.Enum;

namespace Card.Core
{
    /// <summary>
    /// Interface card deck
    /// </summary>
    public interface ICardDeck
    {
        CardDeckEnum DeckType { get; set; }

        string Name { get; set; }

        void AddCard(ICard card);

        void RemoveCard(ICard card);
    }
}

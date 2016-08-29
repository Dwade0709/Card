// ReSharper disable once CheckNamespace
namespace Card.Core
{
    internal class PlayingCardFactory : CardFactory
    {
        public override Card CreateCard(string name, string description, object weight)
        {
            return new PlayingCard() { Description = description, Name = name };
        }
    }
}

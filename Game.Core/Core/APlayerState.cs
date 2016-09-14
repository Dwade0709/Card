namespace Game.Core
{
    /// <summary>
    /// Player state
    /// </summary>
    public abstract class APlayerState
    {
        /// <summary>
        /// Handling state
        /// </summary>
        /// <param name="player">Player for changing state</param>
        public abstract void Handle(IPlayer player);
    }

    /// <summary>
    /// Player state to take a move card
    /// </summary>
    internal class MoveState : APlayerState
    {
        public override void Handle(IPlayer player)
        {
            player.State = new WaitingState();
        }
    }

    /// <summary>
    /// State waiting outher player
    /// </summary>
    internal class WaitingState : APlayerState
    {
        public override void Handle(IPlayer player)
        {
            player.State = new MoveState();
        }
    }
}

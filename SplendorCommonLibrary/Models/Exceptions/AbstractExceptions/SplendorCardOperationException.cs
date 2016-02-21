namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorCardOperationException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorCardOperationException(Player player, Card card)
        {
            this.Player = player;
            this.Card = card;
        }

        #endregion

        #region Public Properties

        public Card Card { get; private set; }

        public Player Player { get; private set; }

        #endregion
    }
}
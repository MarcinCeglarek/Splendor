namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorChipOperationException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorChipOperationException(Player player, Chips chips)
        {
            this.Player = player;
            this.Chips = chips;
        }

        #endregion

        #region Public Properties

        public Chips Chips { get; private set; }

        public Player Player { get; private set; }

        #endregion
    }
}
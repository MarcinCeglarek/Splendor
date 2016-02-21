namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public class SplendorPlayerException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorPlayerException(Player player)
        {
            this.Player = player;
        }

        #endregion

        #region Public Properties

        public Player Player { get; private set; }

        #endregion
    }
}
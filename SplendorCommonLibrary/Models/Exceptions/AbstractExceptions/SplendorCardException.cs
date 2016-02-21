namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorCardException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorCardException(Card card)
        {
            this.Card = card;
        }

        #endregion

        #region Public Properties

        public Card Card { get; private set; }

        #endregion
    }
}
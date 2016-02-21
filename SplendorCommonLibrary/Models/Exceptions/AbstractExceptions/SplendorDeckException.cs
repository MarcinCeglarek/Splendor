namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorDeckException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorDeckException(Deck deck)
        {
            this.Deck = deck;
        }

        #endregion

        #region Public Properties

        public Deck Deck { get; private set; }

        #endregion
    }
}
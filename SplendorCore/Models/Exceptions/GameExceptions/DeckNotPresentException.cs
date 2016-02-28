namespace SplendorCore.Models.Exceptions.DeckExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class DeckNotPresentException : SplendorGameException
    {
        #region Constructors and Destructors

        public DeckNotPresentException(Game game)
            : base(game)
        {
        }

        #endregion
    }
}
namespace SplendorCore.Models.Exceptions.GameExceptions
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
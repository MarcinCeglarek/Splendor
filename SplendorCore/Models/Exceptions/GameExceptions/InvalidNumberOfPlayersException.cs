namespace SplendorCore.Models.Exceptions.GameExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class InvalidNumberOfPlayersException : SplendorGameException
    {
        #region Constructors and Destructors

        public InvalidNumberOfPlayersException(Game game)
            : base(game)
        {
        }

        #endregion
    }
}
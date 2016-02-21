namespace SplendorCore.Models.Exceptions.GameExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class GameNotStartedException : SplendorGameException
    {
        #region Constructors and Destructors

        public GameNotStartedException(Game game)
            : base(game)
        {
        }

        #endregion
    }
}
namespace SplendorCore.Models.Exceptions.GameExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class GameAlreadyStartedException : SplendorGameException
    {
        #region Constructors and Destructors

        public GameAlreadyStartedException(Game game)
            : base(game)
        {
        }

        #endregion
    }
}
namespace SplendorCore.Models.Exceptions.GameExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class GameFinishedException : SplendorGameException
    {
        #region Constructors and Destructors

        public GameFinishedException(Game game)
            : base(game)
        {
        }

        #endregion
    }
}
namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorGameException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorGameException(Game game)
        {
            this.Game = game;
        }

        #endregion

        #region Public Properties

        public Game Game { get; private set; }

        #endregion
    }
}
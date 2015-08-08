namespace SplendorCommonLibrary.Models.Exceptions
{
    public class SplendorGameTakeActionException : SplendorGameException
    {
        #region Constructors and Destructors

        public SplendorGameTakeActionException(string message)
            : base(message)
        {
        }

        #endregion
    }
}
namespace SplendorCommonLibrary.Models.Exceptions
{
    public class SplendorGameTakeActionException : SplendorGameException
    {
        public SplendorGameTakeActionException(string message)
            : base(message)
        {
        }
    }
}
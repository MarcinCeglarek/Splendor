namespace SplendorCore.Models.Exceptions
{
    public class SplendorFileNotFoundException : SplendorException
    {
        #region Constructors and Destructors

        public SplendorFileNotFoundException(string message)
            : base(message)
        {
        }

        #endregion
    }
}
namespace SplendorConsoleServer.Models.Exceptions
{
    #region

    using System;

    #endregion

    public class SplendorServiceException : Exception
    {
        #region Constructors and Destructors

        public SplendorServiceException()
        {
        }

        public SplendorServiceException(string message)
            : base(message)
        {
        }

        public SplendorServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
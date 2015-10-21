namespace SplendorConsoleServer.Models.Exceptions
{
    #region

    using System;

    #endregion

    public class SplendorServiceInvalidRequestException : SplendorServiceException
    {
        #region Constructors and Destructors

        public SplendorServiceInvalidRequestException()
        {
        }

        public SplendorServiceInvalidRequestException(string message)
            : base(message)
        {
        }

        public SplendorServiceInvalidRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
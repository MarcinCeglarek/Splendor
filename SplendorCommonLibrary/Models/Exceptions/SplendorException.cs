namespace SplendorCommonLibrary.Models.Exceptions
{
    #region

    using System;

    #endregion

    public class SplendorException : Exception
    {
        #region Constructors and Destructors

        public SplendorException(string message)
            : base(message)
        {
        }

        #endregion
    }

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
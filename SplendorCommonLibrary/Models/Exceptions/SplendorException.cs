namespace SplendorCore.Models.Exceptions
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
}
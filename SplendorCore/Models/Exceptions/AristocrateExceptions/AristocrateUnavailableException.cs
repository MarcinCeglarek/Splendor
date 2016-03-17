namespace SplendorCore.Models.Exceptions.AristocrateExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class AristocrateUnavailableException : SplendorAristocrateException
    {
        #region Constructors and Destructors

        public AristocrateUnavailableException(Aristocrate aristocrate)
            : base(aristocrate)
        {
        }

        #endregion
    }
}
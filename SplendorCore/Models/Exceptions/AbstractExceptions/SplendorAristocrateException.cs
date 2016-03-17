namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorAristocrateException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorAristocrateException(Aristocrate aristocrate)
        {
            this.Aristocrate = aristocrate;
        }

        #endregion

        #region Public Properties

        public Aristocrate Aristocrate { get; private set; }

        #endregion
    }
}
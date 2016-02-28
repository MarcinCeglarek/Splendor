namespace SplendorCore.Models.Exceptions.AbstractExceptions
{
    public abstract class SplendorFileException : SplendorException
    {
        #region Constructors and Destructors

        protected SplendorFileException(string path)
        {
            this.Path = path;
        }

        #endregion

        #region Public Properties

        public string Path { get; private set; }

        #endregion
    }
}
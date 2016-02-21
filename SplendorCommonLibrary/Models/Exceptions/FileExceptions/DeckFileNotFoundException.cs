namespace SplendorCore.Models.Exceptions.FileExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class DeckFileNotFoundException : SplendorFileException
    {
        #region Constructors and Destructors

        public DeckFileNotFoundException(string path)
            : base(path)
        {
        }

        #endregion
    }
}
namespace SplendorConsoleServer.Models
{
    #region

    using SplendorCommonLibrary.Models;

    #endregion

    public class TakeChipsRequest : GameRequest
    {
        #region Public Properties

        public Chips UserChips { get; set; }

        #endregion
    }
}
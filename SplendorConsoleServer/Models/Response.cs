namespace SplendorConsoleServer.Models
{
    #region

    using SplendorConsoleServer.Models.Enums;

    #endregion

    public class Response
    {
        #region Public Properties

        public string Message { get; set; }

        public ResponseType Type { get; set; }

        #endregion
    }
}
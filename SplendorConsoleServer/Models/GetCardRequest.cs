namespace SplendorConsoleServer.Models
{
    #region

    using System;

    #endregion

    public class GetCardRequest : GameRequest
    {
        #region Public Properties

        public Guid CardId { get; set; }

        #endregion
    }
}
namespace SplendorConsoleServer.Models
{
    #region

    using System;

    #endregion

    public class GameRequest : Request
    {
        #region Public Properties

        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        #endregion
    }
}
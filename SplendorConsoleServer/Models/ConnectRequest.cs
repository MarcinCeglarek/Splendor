namespace SplendorConsoleServer.Models
{
    #region

    using System;

    #endregion

    public class ConnectRequest : Request
    {
        #region Public Properties

        public Guid? GameId { get; set; }

        public Guid? PlayerId { get; set; }

        public string UserName { get; set; }

        #endregion
    }
}
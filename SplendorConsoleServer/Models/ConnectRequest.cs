namespace SplendorConsoleServer.Models
{
    using System;

    public class ConnectRequest : Request
    {
        public Guid? GameId { get; set; }

        public Guid? PlayerId { get; set; }

        public string UserName { get; set; }
    }
}

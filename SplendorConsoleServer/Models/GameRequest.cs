namespace SplendorConsoleServer.Models
{
    using System;

    public class GameRequest : Request
    {
        public Guid GameId { get; set; }

        public Guid UserId { get; set; }
    }
}

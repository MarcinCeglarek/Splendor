namespace SplendorConsoleServer.Models.Abstract
{
    using System;

    public abstract class GameRequest : Request
    {
        public Guid GameId { get; set; }

        public Guid UserId { get; set; }
    }
}

namespace SplendorConsoleServer.Models
{
    using System;

    public class GetCardRequest : GameRequest
    {
        public Guid CardId { get; set; }
    }
}

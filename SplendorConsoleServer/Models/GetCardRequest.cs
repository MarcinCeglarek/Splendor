namespace SplendorConsoleServer.Models
{
    using System;

    using SplendorConsoleServer.Models.Abstract;

    public class GetCardRequest : GameRequest
    {
        public Guid CardId { get; set; }
    }
}

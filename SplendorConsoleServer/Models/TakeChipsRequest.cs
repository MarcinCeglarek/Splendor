namespace SplendorConsoleServer.Models
{
    using SplendorCommonLibrary.Models;

    using SplendorConsoleServer.Models.Abstract;

    public class TakeChipsRequest : GameRequest
    {
        public Chips UserChips { get; set; }
    }
}

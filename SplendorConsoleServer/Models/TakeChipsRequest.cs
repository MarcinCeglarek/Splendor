namespace SplendorConsoleServer.Models
{
    using SplendorCommonLibrary.Models;

    public class TakeChipsRequest : GameRequest
    {
        public Chips UserChips { get; set; }
    }
}

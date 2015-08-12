namespace SplendorConsoleServer.Models
{
    using SplendorConsoleServer.Models.Abstract;

    public class ConnectRequest : Request
    {
        public string UserName { get; set; }
    }
}

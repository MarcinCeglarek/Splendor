namespace SplendorConsoleServer.Models
{
    using SplendorConsoleServer.Models.Enums;

    public class Response
    {
        public ResponseType Type { get; set; }

        public string Message { get; set; }
    }
}

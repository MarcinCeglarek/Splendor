namespace SplendorConsoleServer.Models.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResponseType
    {
        Ok, 

        Error, 
    }
}
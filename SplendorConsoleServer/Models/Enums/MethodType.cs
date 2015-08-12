namespace SplendorConsoleServer.Models.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MethodType
    {
        Connect,

        StartGame,

        GetGameStatus,

        TakeChips,

        ReserveCard,

        PurchaseCard
    }
}
namespace SplendorConsoleServer.Models.Enums
{
    #region

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MethodType
    {
        Invalid, 

        Connect, 

        StartGame, 

        GetGameStatus, 

        TakeChips, 

        ReserveCard, 

        PurchaseCard, 

        ChatMessage
    }
}
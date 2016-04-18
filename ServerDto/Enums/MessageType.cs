namespace ServerDto.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        ShowGames,
        CreateGame,
        JoinGame,
        SendChat,
        PurchaseCard,
        CanPurchaseCard,
        ReserveCard,
        CanReserveCard,
        TakeChips,
        CanTakeChips,

        GameCreated,
        GameJoined,

        GameDeleted,

        DeleteGame
    }
}
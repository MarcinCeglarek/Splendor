namespace ServerDto.Enums
{
    #region Usings

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    #endregion

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        Unset,

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

        DeleteGame,

        GameStatus,

        Subscribe,

        Unsubscribe,

        PlayerJoined,

        PlayerLeft,

        GameStarted,

        GameFinished
    }
}
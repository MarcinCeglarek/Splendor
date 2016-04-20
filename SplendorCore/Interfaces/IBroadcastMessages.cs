namespace SplendorCore.Interfaces
{
    #region

    using SplendorCore.Models;
    using SplendorCore.Models.History;

    #endregion

    public interface IBroadcastMessages
    {
        #region Public Methods and Operators

        void CardPurchased(Game game, Player player, Card card);

        void CardReserved(Game game, Player player, Card card);

        void ChatMessage(Game game, ChatEntry chatEntry);

        void ChipsTaken(Game game, Player player, Chips chips);

        void GameEnded(Game game);

        void GameStarted(Game game);

        void PlayerJoined(Game game, Player player);

        void PlayerLeft(Game game, Player player);

        #endregion
    }
}
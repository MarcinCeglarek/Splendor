namespace SplendorCommonLibrary.Interfaces
{
    #region

    using SplendorCommonLibrary.Models;

    #endregion

    public interface IBroadcastMessages
    {
        #region Public Methods and Operators

        void CardPurchased(Game game);

        void CardReserved(Game game);

        void ChatMessage(ChatEntry chatEntry);

        void ChipsTaken(Game game);

        void GameEnded(Game game);

        void GameStarted(Game game);

        #endregion
    }
}
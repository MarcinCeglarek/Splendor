namespace SplendorCommonLibrary.Interfaces
{
    public interface IBroadcastMessages
    {
        #region Public Methods and Operators

        void CardPurchased();

        void CardReserved();

        void ChipsTaken();

        void GameEnded();

        void GameStarted();

        #endregion
    }
}
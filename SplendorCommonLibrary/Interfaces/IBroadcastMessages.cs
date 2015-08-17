namespace SplendorCommonLibrary.Interfaces
{
    public interface IBroadcastMessages
    {
        void GameStarted();

        void GameEnded();

        void ChipsTaken();

        void CardReserved();

        void CardPurchased();
    }
}

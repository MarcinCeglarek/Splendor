namespace SplendorCommonLibrary.Interfaces
{
    using SplendorCommonLibrary.Models;

    public interface IGameActions
    {
        bool CanPurchaseCard(Player player, Card card);

        void PurchaseCard(Player player, Card card);

        bool CanReserveCard(Player player, Card card);

        void ReserveCard(Player player, Card card);

        bool CanTakeChips(Player player, Chips chips);

        void TakeChips(Player player, Chips chips);
    }
}
namespace SplendorCommonLibrary.Interfaces
{
    #region

    using SplendorCommonLibrary.Models;

    #endregion

    public interface IGameActions
    {
        #region Public Methods and Operators

        bool CanPurchaseCard(Player player, Card card);

        bool CanReserveCard(Player player, Card card);

        bool CanTakeChips(Player player, Chips chips);

        void PurchaseCard(Player player, Card card);

        void ReserveCard(Player player, Card card);

        void TakeChips(Player player, Chips chips);

        #endregion
    }
}
namespace SplendorCore.Interfaces
{
    #region Usings

    using SplendorCore.Models;

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

        void SendMessage(Player player, string message);

        #endregion
    }
}
namespace SplendorCore.Models.History
{
    public class ChipsTaken : HistoryEntry
    {
        #region Constructors and Destructors

        public ChipsTaken(Player player, Chips chips)
            : base(player)
        {
            this.Chips = new Chips(chips);
        }

        #endregion

        #region Public Properties

        public Chips Chips { get; private set; }

        #endregion
    }
}
namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class GoldChip : Chip
    {
        #region Constructors and Destructors

        public GoldChip()
            : this(0)
        {
        }

        public GoldChip(int value)
            : base(Color.Gold, value)
        {
        }

        #endregion
    }
}
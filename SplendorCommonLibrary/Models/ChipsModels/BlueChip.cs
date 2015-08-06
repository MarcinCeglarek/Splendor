namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class BlueChip : Chip
    {
        #region Constructors and Destructors

        public BlueChip()
            : this(0)
        {
        }

        public BlueChip(int value)
            : base(Color.Blue, value)
        {
        }

        #endregion
    }
}
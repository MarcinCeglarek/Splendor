namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class GreenChip : Chip
    {
        #region Constructors and Destructors

        public GreenChip()
            : this(0)
        {
        }

        public GreenChip(int value)
            : base(Color.Green, value)
        {
        }

        #endregion
    }
}
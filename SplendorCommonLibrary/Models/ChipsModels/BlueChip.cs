namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class BlueChip : Chip
    {
        public BlueChip()
            : this(0)
        {    
        }

        public BlueChip(int value)
            : base(Color.Blue, value)
        {
        }
    }
}
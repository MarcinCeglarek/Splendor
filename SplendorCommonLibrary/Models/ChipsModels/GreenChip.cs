namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class GreenChip : Chip
    {
        public GreenChip()
            : this(0)
        {    
        }

        public GreenChip(int value)
            : base(Color.Green, value)
        {
        }
    }
}
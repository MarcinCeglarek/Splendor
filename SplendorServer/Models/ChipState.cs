namespace MvcApplication1.Models
{
    public class ChipState
    {
        public int White { get; set; }

        public int Blue { get; set; }

        public int Green { get; set; }

        public int Red { get; set; }

        public int Black { get; set; }

        public int Gold { get; set; }

        public static ChipState operator +(ChipState a, ChipState b)
        {
            return new ChipState()
                       {
                           White = a.White + b.White,
                           Black = a.Black + b.Black,
                           Blue = a.Blue + b.Blue,
                           Gold = a.Gold + b.Gold,
                           Green = a.Green + b.Green,
                           Red = a.Red + b.Red
                       };
        }

        public static ChipState operator -(ChipState a, ChipState b)
        {
            return new ChipState()
            {
                White = a.White - b.White,
                Black = a.Black - b.Black,
                Blue = a.Blue - b.Blue,
                Gold = a.Gold - b.Gold,
                Green = a.Green - b.Green,
                Red = a.Red - b.Red
            };
        }
    }
}
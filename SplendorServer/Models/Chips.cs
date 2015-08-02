namespace SplendorServer.Models
{
    public class Chips
    {
        public int White { get; set; }

        public int Blue { get; set; }

        public int Green { get; set; }

        public int Red { get; set; }

        public int Black { get; set; }

        public int Gold { get; set; }

        public static Chips operator +(Chips a, Chips b)
        {
            return new Chips()
                       {
                           White = a.White + b.White,
                           Black = a.Black + b.Black,
                           Blue = a.Blue + b.Blue,
                           Gold = a.Gold + b.Gold,
                           Green = a.Green + b.Green,
                           Red = a.Red + b.Red
                       };
        }

        public static Chips operator -(Chips a, Chips b)
        {
            return new Chips()
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
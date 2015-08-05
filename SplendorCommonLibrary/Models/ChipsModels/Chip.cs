namespace SplendorCommonLibrary.Models.ChipsModels
{
    using System;

    using SplendorCommonLibrary.Data;

    public abstract class Chip
    {
        protected Chip(Color color, int value)
        {
            this.Color = color;
            this.Value = value;
        }

        public Color Color { get; set; }

        public int Value { get; set; }

        public static Chip operator +(Chip a, Chip b)
        {
            if (a.Color == b.Color)
            {
                var className = a.GetType().Name;
                return (Chip)Activator.CreateInstance(typeof(Chip).Assembly.FullName, Constants.ChipClassPath + className).Unwrap();
            }

            throw new ArgumentException("Object's type does not match");
        }
    }
}

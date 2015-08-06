namespace SplendorCommonLibrary.Models.ChipsModels
{
    #region

    using System;

    using SplendorCommonLibrary.Data;

    #endregion

    public abstract class Chip
    {
        #region Constructors and Destructors

        protected Chip(Color color, int value)
        {
            this.Color = color;
            this.Value = value;
        }

        #endregion

        #region Public Properties

        public Color Color { get; set; }

        public int Value { get; set; }

        #endregion

        #region Public Methods and Operators

        public static Chip operator +(Chip a, Chip b)
        {
            if (a.Color == b.Color)
            {
                var className = a.GetType().Name;
                return (Chip)Activator.CreateInstance(typeof(Chip).Assembly.FullName, Constants.ChipClassPath + className).Unwrap();
            }

            throw new ArgumentException("Object's type does not match");
        }

        #endregion
    }
}
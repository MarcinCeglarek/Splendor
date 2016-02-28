namespace SplendorFormsClient
{
    #region

    using System;
    using System.Drawing;

    using SplendorColor = SplendorCore.Models.Color;

    #endregion

    public class FormsColor
    {
        #region Static Fields

        private static readonly Color Black = Color.Black;

        private static readonly Color Blue = Color.RoyalBlue;

        private static readonly Color Gold = Color.Gold;

        private static readonly Color Green = Color.LimeGreen;

        private static readonly Color Red = Color.OrangeRed;

        private static readonly Color White = Color.GhostWhite;

        #endregion

        #region Public Methods and Operators

        public static Color ForeColor(SplendorColor color)
        {
            switch (color)
            {
                case SplendorColor.Black:
                    return White;
                case SplendorColor.Blue:
                    return White;
                case SplendorColor.Gold:
                    return Black;
                case SplendorColor.Green:
                    return White;
                case SplendorColor.Red:
                    return White;
                case SplendorColor.White:
                    return Black;
            }

            throw new NotSupportedException();
        }

        public static Color BackColor(SplendorColor color)
        {
            switch (color)
            {
                case SplendorColor.Black:
                    return Black;
                case SplendorColor.Blue:
                    return Blue;
                case SplendorColor.Gold:
                    return Gold;
                case SplendorColor.Green:
                    return Green;
                case SplendorColor.Red:
                    return Red;
                case SplendorColor.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        public static Color DisabledForeColor(SplendorColor color)
        {
            switch (color)
            {
                case SplendorColor.Black:
                    return Black;
                case SplendorColor.Blue:
                    return Blue;
                case SplendorColor.Gold:
                    return Gold;
                case SplendorColor.Green:
                    return Green;
                case SplendorColor.Red:
                    return Red;
                case SplendorColor.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        public static Color DisabledBackColor(SplendorColor color)
        {
            switch (color)
            {
                case SplendorColor.Black:
                    return Black;
                case SplendorColor.Blue:
                    return Blue;
                case SplendorColor.Gold:
                    return Gold;
                case SplendorColor.Green:
                    return Green;
                case SplendorColor.Red:
                    return Red;
                case SplendorColor.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        #endregion
    }
}
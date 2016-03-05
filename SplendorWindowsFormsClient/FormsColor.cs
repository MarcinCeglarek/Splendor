namespace SplendorWindowsFormsClient
{
    #region

    using System;
    using System.Drawing;

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

        public static Color BackColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Black;
                case SplendorCore.Models.Color.Blue:
                    return Blue;
                case SplendorCore.Models.Color.Gold:
                    return Gold;
                case SplendorCore.Models.Color.Green:
                    return Green;
                case SplendorCore.Models.Color.Red:
                    return Red;
                case SplendorCore.Models.Color.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        public static Color DisabledBackColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Black;
                case SplendorCore.Models.Color.Blue:
                    return Blue;
                case SplendorCore.Models.Color.Gold:
                    return Gold;
                case SplendorCore.Models.Color.Green:
                    return Green;
                case SplendorCore.Models.Color.Red:
                    return Red;
                case SplendorCore.Models.Color.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        public static Color DisabledForeColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Black;
                case SplendorCore.Models.Color.Blue:
                    return Blue;
                case SplendorCore.Models.Color.Gold:
                    return Gold;
                case SplendorCore.Models.Color.Green:
                    return Green;
                case SplendorCore.Models.Color.Red:
                    return Red;
                case SplendorCore.Models.Color.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        public static Color ForeColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return White;
                case SplendorCore.Models.Color.Blue:
                    return White;
                case SplendorCore.Models.Color.Gold:
                    return Black;
                case SplendorCore.Models.Color.Green:
                    return White;
                case SplendorCore.Models.Color.Red:
                    return White;
                case SplendorCore.Models.Color.White:
                    return Black;
            }

            throw new NotSupportedException();
        }

        #endregion
    }
}
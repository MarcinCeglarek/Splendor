namespace SplendorWpfClient.ValueConverters
{
    #region

    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Data;

    using SplendorColor = SplendorCore.Models.Color;

    #endregion

    public class ColorToBrush : IValueConverter
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

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SplendorColor)
            {
                
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
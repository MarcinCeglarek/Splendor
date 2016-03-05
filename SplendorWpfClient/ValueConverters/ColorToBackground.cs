namespace SplendorWpfClient.ValueConverters
{
    #region

    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    using SplendorColor = SplendorCore.Models.Color;

    #endregion

    public class ColorToBackground : IValueConverter
    {
        #region Static Fields

        private static readonly Color Black = Colors.Black;

        private static readonly Color Blue = Colors.RoyalBlue;

        private static readonly Color Gold = Colors.Gold;

        private static readonly Color Green = Colors.LimeGreen;

        private static readonly Color Red = Colors.OrangeRed;

        private static readonly Color White = Colors.GhostWhite;

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
                return new SolidColorBrush(ForeColor((SplendorColor)value));
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
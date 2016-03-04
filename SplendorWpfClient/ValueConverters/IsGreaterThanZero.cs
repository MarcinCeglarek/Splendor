namespace SplendorWpfClient.ValueConverters
{
    #region

    using System;
    using System.Globalization;
    using System.Windows.Data;

    #endregion

    public class IsGreaterThanZero : IValueConverter
    {
        #region Public Methods and Operators

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int && (int)value > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
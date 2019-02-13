using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Milky.OsbOptimizer.Converters
{
    class StringBuilderVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sb = (StringBuilder)value;
            if (sb == null)
                return Visibility.Hidden;
            return sb.Length == 0 ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class StringBuilderToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var sb = (StringBuilder)value;
            return sb?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
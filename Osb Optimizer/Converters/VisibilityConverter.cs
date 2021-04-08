using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Milki.OsbOptimizer.Converters
{
    class VisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                var isRunning = (bool)values[0];
                var isFinished = (bool)values[1];
                if (!isRunning && isFinished)
                {
                    return Visibility.Visible;
                }

                return Visibility.Hidden;
            }

            return null;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class BarWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                var winWidth = (double)values[0];
                var panelWidth = (double)values[1];
                return winWidth - panelWidth - 25;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class BarWidthConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 200;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

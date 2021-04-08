using System;
using System.Globalization;
using System.Windows.Data;

namespace Milki.OsbOptimizer.Converters
{
    class EnabledConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                var isRunning = (bool)values[0];
                var isFinished = (bool)values[1];
                if (!isRunning)
                {
                    return true;
                }
                return false;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
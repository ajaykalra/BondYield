using System;
using System.Globalization;
using System.Windows.Data;

namespace BondYieldCalculator.Wpf.Calculator
{
    public class PriceYieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            
            return ((double)value).ToString($"F7");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace ConcurrencyPatterns.WPF.Resources.Converters;

[ValueConversion(typeof(double), typeof(int))]
public class HeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double val && parameter is int param ? val + param : 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is double val && parameter is int param ? val - param : 0;
}

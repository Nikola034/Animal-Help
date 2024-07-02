using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AnimalHelp.WPF.Views.Donations;

public class AmountColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is float amount)
        {
            return amount < 0 ? Brushes.Red : Brushes.Green;
        }
        return Brushes.Black;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

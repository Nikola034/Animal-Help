namespace AnimalHelp.WPF.Views.Volounteer.BlackList;

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

public class RatingToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is float rating)
        {
            return rating switch
            {
                >= 4.5f => Brushes.Green,
                >= 3.0f => Brushes.Orange,
                _ => Brushes.Red,
            };
        }
        return Brushes.Black;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

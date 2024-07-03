using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.WPF.Views.Volounteer.BlackList;

public class UserTypeToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is UserType userType)
        {
            return userType switch
            {
                UserType.Member => Brushes.Orange,
                UserType.Volunteer => Brushes.Green,
                UserType.Admin => Brushes.Blue,
                _ => Brushes.Black,
            };
        }
        return Brushes.Black;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

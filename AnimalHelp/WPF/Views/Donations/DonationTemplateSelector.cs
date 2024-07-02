using System.Windows;
using System.Windows.Controls;
using AnimalHelp.WPF.ViewModels.Donations;

namespace AnimalHelp.WPF.Views.Donations;

public class DonationTemplateSelector : DataTemplateSelector
{
    public DataTemplate? DonationTemplate { get; set; }
    public DataTemplate? TransactionTemplate { get; set; }

    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        return item switch
        {
            DonationViewModel => DonationTemplate,
            TransactionViewModel => TransactionTemplate,
            _ => base.SelectTemplate(item, container)
        };
    }
}
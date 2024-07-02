using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Donations;

public partial class ImportTransactionsWindow : NavigableWindow
{
    public ImportTransactionsWindow(ImportTransactionsViewModel viewModel, IAnimalHelpWindowFactory windowFactory)
        : base(viewModel, windowFactory)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
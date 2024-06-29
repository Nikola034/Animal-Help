using AnimalHelp.WPF.ViewModels;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views;

public partial class MainWindow
{
    public MainWindow(MainViewModel mainViewModel, IAnimalHelpWindowFactory windowFactory)
        : base(mainViewModel, windowFactory)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}
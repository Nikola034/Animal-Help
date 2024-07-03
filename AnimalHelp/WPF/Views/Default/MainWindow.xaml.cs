using AnimalHelp.WPF.ViewModels.Default;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Default;

public partial class MainWindow
{
    public MainWindow(MainViewModel mainViewModel, IAnimalHelpWindowFactory windowFactory)
        : base(mainViewModel, windowFactory)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }
}
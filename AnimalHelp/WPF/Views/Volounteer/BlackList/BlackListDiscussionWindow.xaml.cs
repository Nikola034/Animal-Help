using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Volounteer.BlackList;
using AnimalHelp.WPF.Views.Factories;

namespace AnimalHelp.WPF.Views.Volounteer.BlackList;

public partial class BlackListDiscussionWindow : NavigableWindow
{
    public BlackListDiscussionWindow(BlackListDiscussionViewModel viewModel, IAnimalHelpWindowFactory windowFactory)
        : base(viewModel, windowFactory)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
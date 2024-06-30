using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Factories;

public interface IAnimalHelpViewModelFactory
{
    public ViewModelBase CreateViewModel(ViewType viewType);
}
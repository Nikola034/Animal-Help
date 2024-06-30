using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.Application.Utility.Navigation;

public abstract class NavigationServiceBase : INavigationService
{
    protected readonly NavigationStore NavigationStore;
    protected readonly IAnimalHelpViewModelFactory ViewModelFactory;

    protected NavigationServiceBase(NavigationStore navigationStore, IAnimalHelpViewModelFactory viewModelFactory)
    {
        NavigationStore = navigationStore;
        ViewModelFactory = viewModelFactory;
    }

    public abstract void Navigate(ViewType viewType);
}
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.Application.Utility.Navigation;

internal class NavigationService : NavigationServiceBase
{ 
    public NavigationService(NavigationStore navigationStore, IAnimalHelpViewModelFactory viewModelFactory)
        : base(navigationStore, viewModelFactory) {}

    public override void Navigate(ViewType viewType)
    {
        NavigationStore.CurrentViewModel = ViewModelFactory.CreateViewModel(viewType);
        NavigationStore.ViewType = viewType;
    }
}
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.Application.Utility.Navigation;

public class PopupNavigationService : NavigationServiceBase, IPopupNavigationService
{
    public PopupNavigationService(NavigationStore navigationStore, IAnimalHelpViewModelFactory viewModelFactory)
        : base(navigationStore, viewModelFactory) {}

    public override void Navigate(ViewType viewType)
    {
        NavigationStore.AddPopup(ViewModelFactory.CreateViewModel(viewType));
    }
}
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.Application.Utility.Navigation;

public class ClosePopupNavigationService : NavigationServiceBase, IClosePopupNavigationService
{
    public ClosePopupNavigationService(NavigationStore navigationStore, IAnimalHelpViewModelFactory viewModelFactory)
        : base(navigationStore, viewModelFactory) {}

    public override void Navigate(ViewType viewType)
    {
        NavigationStore.ClosePopup();
    }
}
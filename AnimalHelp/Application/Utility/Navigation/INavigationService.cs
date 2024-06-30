using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.Application.Utility.Navigation;

public interface INavigationService
{
    public void Navigate(ViewType viewType);
}

public interface IPopupNavigationService : INavigationService
{
}

public interface IClosePopupNavigationService : INavigationService
{
}
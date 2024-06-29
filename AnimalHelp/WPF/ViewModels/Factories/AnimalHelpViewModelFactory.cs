using System;
using AnimalHelp.WPF.MVVM;
using LangLang.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Factories;

public class AnimalHelpViewModelFactory : IAnimalHelpViewModelFactory
{
    private readonly CreateViewModel<MainViewModel> _createMainViewModel;

    public AnimalHelpViewModelFactory(CreateViewModel<MainViewModel> createMainViewModel)
    {
        _createMainViewModel = createMainViewModel;
    }

    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Main => _createMainViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
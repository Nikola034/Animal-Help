using System;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Common;

namespace AnimalHelp.WPF.ViewModels.Factories;

public class AnimalHelpViewModelFactory : IAnimalHelpViewModelFactory
{
    private readonly CreateViewModel<MainViewModel> _createMainViewModel;
    private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
    private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;


    public AnimalHelpViewModelFactory(CreateViewModel<MainViewModel> createMainViewModel,
        CreateViewModel<LoginViewModel> createLoginViewModel,
        CreateViewModel<RegisterViewModel> createRegisterViewModel)
    {
        _createMainViewModel = createMainViewModel;
        _createLoginViewModel = createLoginViewModel;
        _createRegisterViewModel = createRegisterViewModel;
    }

    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Main => _createMainViewModel(),
            ViewType.Login => _createLoginViewModel(),
            ViewType.Register => _createRegisterViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
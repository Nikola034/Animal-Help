using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
<<<<<<< HEAD
using AnimalHelp.WPF.ViewModels.Member;
=======
using System;
>>>>>>> dc231a7ae30a6da80d6cb8108d6dfa94f2720c33

namespace AnimalHelp.WPF.ViewModels.Factories;

public class AnimalHelpViewModelFactory : IAnimalHelpViewModelFactory
{
    private readonly CreateViewModel<MainViewModel> _createMainViewModel;
    private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
    private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
<<<<<<< HEAD
    private readonly CreateViewModel<CreatePostViewModel> _createPostViewModel;
=======
    private readonly CreateViewModel<AdminMenuViewModel> _createAdminViewModel;
    private readonly CreateViewModel<VolunteerRegistrationViewModel> _createVolunteerRegistrationViewModel;
>>>>>>> dc231a7ae30a6da80d6cb8108d6dfa94f2720c33


    public AnimalHelpViewModelFactory(CreateViewModel<MainViewModel> createMainViewModel,
        CreateViewModel<LoginViewModel> createLoginViewModel,
<<<<<<< HEAD
        CreateViewModel<RegisterViewModel> createRegisterViewModel, CreateViewModel<CreatePostViewModel> createPostViewModel)
=======
        CreateViewModel<RegisterViewModel> createRegisterViewModel,
        CreateViewModel<AdminMenuViewModel> createAdminViewModel,
        CreateViewModel<VolunteerRegistrationViewModel> createVolunteerRegistrationViewModel
        )
>>>>>>> dc231a7ae30a6da80d6cb8108d6dfa94f2720c33
    {
        _createMainViewModel = createMainViewModel;
        _createLoginViewModel = createLoginViewModel;
        _createRegisterViewModel = createRegisterViewModel;
<<<<<<< HEAD
        _createPostViewModel = createPostViewModel;
=======
        _createAdminViewModel = createAdminViewModel;
        _createVolunteerRegistrationViewModel = createVolunteerRegistrationViewModel;
>>>>>>> dc231a7ae30a6da80d6cb8108d6dfa94f2720c33
    }

    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Main => _createMainViewModel(),
            ViewType.Login => _createLoginViewModel(),
            ViewType.Register => _createRegisterViewModel(),
<<<<<<< HEAD
            ViewType.CreatePost => _createPostViewModel(),
=======
            ViewType.Admin => _createAdminViewModel(),
            ViewType.VolunteerTable => _createVolunteerRegistrationViewModel(),
>>>>>>> dc231a7ae30a6da80d6cb8108d6dfa94f2720c33
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
using System;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.ViewModels.Volounteer;

namespace AnimalHelp.WPF.ViewModels.Factories;

public class AnimalHelpViewModelFactory(
    CreateViewModel<MainViewModel> createMainViewModel,
    CreateViewModel<LoginViewModel> createLoginViewModel,
    CreateViewModel<RegisterViewModel> createRegisterViewModel,
    CreateViewModel<CreatePostViewModel> createPostViewModel,
    CreateViewModel<AdminMenuViewModel> createAdminViewModel,
    CreateViewModel<VolunteerRegistrationViewModel> createVolunteerRegistrationViewModel,
    CreateViewModel<VolounteerMenuViewModel> createVolunteerMenuViewModel,
    CreateViewModel<MemberMenuViewModel> createMemberMenuViewModel,
    CreateViewModel<CreateDonationViewModel> createDonationViewModel)
    : IAnimalHelpViewModelFactory
{
    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Main => createMainViewModel(),
            ViewType.Login => createLoginViewModel(),
            ViewType.Register => createRegisterViewModel(),
            ViewType.CreatePost => createPostViewModel(),
            ViewType.Admin => createAdminViewModel(),
            ViewType.VolunteerTable => createVolunteerRegistrationViewModel(),
            ViewType.VolounteerMenu => createVolunteerMenuViewModel(),
            ViewType.MemberMenu => createMemberMenuViewModel(),
            ViewType.CreateDonation => createDonationViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
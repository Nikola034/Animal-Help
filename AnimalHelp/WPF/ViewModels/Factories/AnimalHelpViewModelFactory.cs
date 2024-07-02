using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.ViewModels.Volounteer;
using System;

namespace AnimalHelp.WPF.ViewModels.Factories;

public class AnimalHelpViewModelFactory
    : IAnimalHelpViewModelFactory
{
    private readonly CreateViewModel<MainViewModel> _createMainViewModel;
    private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
    private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
    private readonly CreateViewModel<CreatePostViewModel> _createPostViewModel;
    private readonly CreateViewModel<AdminMenuViewModel> _createAdminViewModel;
    private readonly CreateViewModel<VolunteerRegistrationViewModel> _createVolunteerRegistrationViewModel;
    private readonly CreateViewModel<VolounteerMenuViewModel> _createVolunteerMenuViewModel;
    private readonly CreateViewModel<MemberMenuViewModel> _createMemberMenuViewModel;
    private readonly CreateViewModel<CreateDonationViewModel> _createDonationViewModel;
    private readonly CreateViewModel<FeedViewModel> _createFeedViewModel;
    private readonly CreateViewModel<VotingViewModel> _createVotingViewModel;
    private readonly CreateViewModel<ApprovePostsViewModel> _createApprovePostsViewModel;
    private readonly CreateViewModel<CreateAnimalViewModel> _createAnimalViewModel;
    private readonly CreateViewModel<AgencyInformationViewModel> _agencyInformationViewModel;
    private readonly CreateViewModel<AdoptionRequestViewModel> _adoptionRequestViewModel;
    private readonly CreateViewModel<AdoptionsOverviewViewModel> _adoptionsOverviewViewModel;
    private readonly CreateViewModel<RateAnimalViewModel> _rateAnimalViewModel;

    public AnimalHelpViewModelFactory(CreateViewModel<MainViewModel> createMainViewModel,
        CreateViewModel<LoginViewModel> createLoginViewModel,
        CreateViewModel<RegisterViewModel> createRegisterViewModel, 
        CreateViewModel<CreatePostViewModel> createPostViewModel,
        CreateViewModel<AdminMenuViewModel> createAdminViewModel,
        CreateViewModel<VolunteerRegistrationViewModel> createVolunteerRegistrationViewModel,
        CreateViewModel<VolounteerMenuViewModel> createVolunteerMenuViewModel,
        CreateViewModel<MemberMenuViewModel> createMemberMenuViewModel,
        CreateViewModel<CreateDonationViewModel>  createDonationViewModel,
        CreateViewModel<FeedViewModel> createFeedViewModel,
        CreateViewModel<ApprovePostsViewModel> createApprovePostsViewModel,
        CreateViewModel<CreateAnimalViewModel> createAnimalViewModel,
        CreateViewModel<AgencyInformationViewModel> agencyInformationViewModel,
        CreateViewModel<AdoptionRequestViewModel> adoptionRequestViewModel,
        CreateViewModel<AdoptionsOverviewViewModel>adoptionOverviewViewModel,
        CreateViewModel<RateAnimalViewModel> rateAnimalViewModel,
        CreateViewModel<VotingViewModel> votingViewModel
        )
    {
        _createMainViewModel = createMainViewModel;
        _createLoginViewModel = createLoginViewModel;
        _createRegisterViewModel = createRegisterViewModel;
        _createPostViewModel = createPostViewModel;
        _createAdminViewModel = createAdminViewModel;
        _createVolunteerRegistrationViewModel = createVolunteerRegistrationViewModel;
        _createVolunteerMenuViewModel = createVolunteerMenuViewModel;
        _createMemberMenuViewModel = createMemberMenuViewModel;
        _createDonationViewModel = createDonationViewModel;
        _createFeedViewModel = createFeedViewModel;
        _createApprovePostsViewModel = createApprovePostsViewModel;
        _createAnimalViewModel = createAnimalViewModel;
        _agencyInformationViewModel = agencyInformationViewModel;
        _adoptionRequestViewModel = adoptionRequestViewModel;
        _adoptionsOverviewViewModel = adoptionOverviewViewModel;
        _rateAnimalViewModel = rateAnimalViewModel;
        _createVotingViewModel = votingViewModel;
    }
    public ViewModelBase CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Main => _createMainViewModel(),
            ViewType.Login => _createLoginViewModel(),
            ViewType.Register => _createRegisterViewModel(),
            ViewType.CreatePost => _createPostViewModel(),
            ViewType.Admin => _createAdminViewModel(),
            ViewType.VolunteerTable => _createVolunteerRegistrationViewModel(),
            ViewType.VotingVolunteer => _createVotingViewModel(),
            ViewType.VolounteerMenu => _createVolunteerMenuViewModel(),
            ViewType.MemberMenu => _createMemberMenuViewModel(),
            ViewType.CreateDonation => _createDonationViewModel(),
            ViewType.Feed => _createFeedViewModel(),
            ViewType.ApprovePosts => _createApprovePostsViewModel(),
            ViewType.Animals => _createAnimalViewModel(),
            ViewType.AgencyInfo => _agencyInformationViewModel(),
            ViewType.AdoptionRequest => _adoptionRequestViewModel(),
            ViewType.AdoptionsOverview => _adoptionsOverviewViewModel(),
            ViewType.RateAnimal => _rateAnimalViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
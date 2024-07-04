using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.ViewModels.Volounteer;
using AnimalHelp.WPF.ViewModels.Default;
using AnimalHelp.WPF.ViewModels.Volounteer.BlackList;
using System;

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
    CreateViewModel<CreateDonationViewModel> createDonationViewModel,
    CreateViewModel<FeedViewModel> createFeedViewModel,
    CreateViewModel<ApprovePostsViewModel> createApprovePostsViewModel,
    CreateViewModel<CreateAnimalViewModel> createAnimalViewModel,
    CreateViewModel<AgencyInformationViewModel> agencyInformationViewModel,
    CreateViewModel<AdoptionRequestViewModel> adoptionRequestViewModel,
    CreateViewModel<AdoptionsOverviewViewModel> adoptionOverviewViewModel,
    CreateViewModel<RateAnimalViewModel> rateAnimalViewModel,
    CreateViewModel<VotingViewModel> votingViewModel,
    CreateViewModel<BlackListViewModel> createBlackListViewModel,
    CreateViewModel<BlackListDiscussionViewModel> createBlackListDiscussionViewModel,
    CreateViewModel<SimpleFeedViewModel> createSimpleFeedViewModel,
    CreateViewModel<DonationsListViewModel> createDonationsListViewModel,
    CreateViewModel<ImportTransactionsViewModel> createImportTransactionsViewModel,
    CreateViewModel<DonationsOverviewViewModel> createDonationsOverviewViewModel
    )
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
            ViewType.VotingVolunteer => votingViewModel(),
            ViewType.VolounteerMenu => createVolunteerMenuViewModel(),
            ViewType.MemberMenu => createMemberMenuViewModel(),
            ViewType.CreateDonation => createDonationViewModel(),
            ViewType.Feed => createFeedViewModel(),
            ViewType.ApprovePosts => createApprovePostsViewModel(),
            ViewType.Animals => createAnimalViewModel(),
            ViewType.AgencyInfo => agencyInformationViewModel(),
            ViewType.AdoptionRequest => adoptionRequestViewModel(),
            ViewType.AdoptionsOverview => adoptionOverviewViewModel(),
            ViewType.RateAnimal => rateAnimalViewModel(),
            ViewType.BlackList => createBlackListViewModel(),
            ViewType.BlackListDiscussion => createBlackListDiscussionViewModel(),
            ViewType.SimpleFeed => createSimpleFeedViewModel(),
            ViewType.DonationList => createDonationsListViewModel(),
            ViewType.TransactionImport => createImportTransactionsViewModel(),
            ViewType.DonationsOverview => createDonationsOverviewViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "No ViewModel exists for the given ViewType: " + viewType)
        };
    }
}
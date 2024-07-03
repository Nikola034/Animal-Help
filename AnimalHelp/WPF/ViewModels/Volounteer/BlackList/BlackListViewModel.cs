using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Services.User;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Volounteer.BlackList;

public class BlackListViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    private readonly IBlackListService _blackListService;
    private readonly IAdoptionService _adoptionService;
    private readonly IPopupNavigationService _popupNavigationService;
    private readonly CurrentBlackListProposalStore _currentBlackListProposalStore;

    private ObservableCollection<BlackListProposalViewModel> _proposals = null!;
    private ObservableCollection<UserViewModel> _blacklistedUsers = null!;
    private ObservableCollection<UserViewModel> _activeUsers = null!;

    public ICommand ProposeForBlackListCommand { get; }
    public ICommand OpenDiscussionCommand { get; }

    public BlackListViewModel(
        NavigationStore navigationStore, 
        IBlackListService blackListService,
        IAdoptionService adoptionService,
        IPopupNavigationService popupNavigationService, 
        CurrentBlackListProposalStore currentBlackListProposalStore
        )
    {
        _navigationStore = navigationStore;
        _blackListService = blackListService;
        _adoptionService = adoptionService;
        _popupNavigationService = popupNavigationService;
        _currentBlackListProposalStore = currentBlackListProposalStore;

        LoadUserLists();

        ProposeForBlackListCommand = new RelayCommand(ProposeForBlackList);
        OpenDiscussionCommand = new RelayCommand(OpenDiscussion);
    }

    public ObservableCollection<BlackListProposalViewModel> Proposals
    {
        get => _proposals;
        set => SetField(ref _proposals, value);
    }
    public ObservableCollection<UserViewModel> BlackListedUsers
    {
        get => _blacklistedUsers;
        set => SetField(ref _blacklistedUsers, value);
    }

    public ObservableCollection<UserViewModel> ActiveUsers
    {
        get => _activeUsers;
        set => SetField(ref _activeUsers, value);
    }
    
    private void LoadUserLists()
    {
        Proposals = new ObservableCollection<BlackListProposalViewModel>(
            _blackListService.GetActiveBlackListProposals().Select(ConvertToBlackListProposalViewModel));
        BlackListedUsers = new ObservableCollection<UserViewModel>(
            _blackListService.GetBlackListedUsers().Select(ConvertToUserViewModel));
        ActiveUsers = new ObservableCollection<UserViewModel>(
            _blackListService.GetActiveUsers().Select(ConvertToUserViewModel));
    }

    private UserViewModel ConvertToUserViewModel(UserDto userDto)
    {
        float? rating = null;
        if (userDto.UserType == UserType.Member)
            rating = _adoptionService.GetMemberRating(userDto.Person!.Profile.Email);
        return new UserViewModel(userDto, rating);
    }

    private BlackListProposalViewModel ConvertToBlackListProposalViewModel(BlackListProposalDto proposalDto)
    {
        return new BlackListProposalViewModel(
            ConvertToUserViewModel(proposalDto.User),
            proposalDto
        );
    }
    
    private void ProposeForBlackList(object? obj)
    {
        if (obj is not UserViewModel userViewModel)
            return;
        var proposal = _blackListService.ProposeForBlackList(userViewModel.User);
        _proposals.Add(ConvertToBlackListProposalViewModel(proposal));
        _activeUsers.Remove(userViewModel);
    }
    
    private void OpenDiscussion(object? obj)
    {
        if (obj is not BlackListProposalViewModel proposalViewModel)
            return;
        _currentBlackListProposalStore.BlackListProposalDto = proposalViewModel.Proposal;
        _popupNavigationService.Navigate(ViewType.BlackListDiscussion);
        _navigationStore.PopupClosed += OnPopupClosed;
    }
    
    private void OnPopupClosed()
    {
        LoadUserLists();
        _navigationStore.PopupClosed -= OnPopupClosed;
    }
}
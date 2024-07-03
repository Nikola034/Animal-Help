using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Services.User;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.BlackList;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Volounteer.BlackList;

public class BlackListDiscussionViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }
    private readonly IBlackListService _blackListService;
    private readonly IAdoptionService _adoptionService;
    private readonly IVolunteerService _volunteerService;
    private readonly IClosePopupNavigationService _closePopupNavigationService;

    private readonly Volunteer _currentUser;

    private BlackListProposalViewModel _proposal;
    private string _messageText = "";

    private ObservableCollection<MessageViewModel> _messages;

    public ICommand AddMessageCommand { get; }
    public ICommand AcceptProposalCommand { get; }
    public ICommand RejectProposalCommand { get; }

    public BlackListDiscussionViewModel(NavigationStore navigationStore, CurrentBlackListProposalStore currentBlackListProposalStore, IBlackListService blackListService, IAdoptionService adoptionService, IVolunteerService volunteerService, IAuthenticationStore authenticationStore, IClosePopupNavigationService closePopupNavigationService)
    {
        NavigationStore = navigationStore;
        _blackListService = blackListService;
        _adoptionService = adoptionService;
        _volunteerService = volunteerService;
        _closePopupNavigationService = closePopupNavigationService;

        if (currentBlackListProposalStore.BlackListProposalDto == null)
            throw new InvalidOperationException("No BlackListProposal stored.");
        _proposal = ConvertToBlackListProposalViewModel(currentBlackListProposalStore.BlackListProposalDto);

        if (authenticationStore.UserType != UserType.Volunteer)
            throw new InvalidOperationException("Only volunteers can discuss blacklist proposals.");

        _currentUser = authenticationStore.CurrentUser.Person as Volunteer ??
                       throw new ArgumentException("No logged in volunteer.");
        
        _messages = new ObservableCollection<MessageViewModel>(
            currentBlackListProposalStore.BlackListProposalDto.Proposal.Messages
                .Select(ConvertToMessageViewModel)
        );

        AddMessageCommand = new RelayCommand(_ => AddMessage(), _ => CanAddMessage());
        AcceptProposalCommand = new RelayCommand(_ => AcceptProposal());
        RejectProposalCommand = new RelayCommand(_ => RejectProposal());
    }

    public BlackListProposalViewModel Proposal
    {
        get => _proposal;
        set => SetField(ref _proposal, value);
    }

    public string MessageText
    {
        get => _messageText;
        set => SetField(ref _messageText, value);
    }

    public ObservableCollection<MessageViewModel> Messages
    {
        get => _messages;
        set => SetField(ref _messages, value);
    }
    
    
    private void AddMessage()
    {
        var message = _blackListService.AddMessageToDiscussion(Proposal.Proposal.Proposal, _currentUser, MessageText);
        MessageText = "";
        Messages.Add(ConvertToMessageViewModel(message));
    }

    private bool CanAddMessage()
    {
        return MessageText != "";
    }
    
    
    private void AcceptProposal()
    {
        _blackListService.AcceptProposal(Proposal.Proposal.Proposal);
        MessageBox.Show("User blacklisted successfully.");
        _closePopupNavigationService.Navigate(ViewType.BlackListDiscussion);
    }

    private void RejectProposal()
    {
        _blackListService.RejectProposal(Proposal.Proposal.Proposal);
        MessageBox.Show("Blacklist proposal rejected.");
        _closePopupNavigationService.Navigate(ViewType.BlackListDiscussion);
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

    private MessageViewModel ConvertToMessageViewModel(Message message)
    {
        return new MessageViewModel(
            message,
            _volunteerService.GetVolunteerById(message.AuthorId)?.Name ?? ""
        );
    }
}
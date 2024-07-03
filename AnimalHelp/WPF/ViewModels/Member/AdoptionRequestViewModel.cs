using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Stores;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Member;

public class AdoptionRequestViewModel:ViewModelBase, INavigableDataContext
{
    public static event Action? AdoptionRequestsUpdated;
    public NavigationStore NavigationStore { get; }
    public ICommand ApplyCommand { get; }

    private readonly IAdoptionRequestService _adoptionRequestService;
    private readonly CurrentPostStore _currentPostStore;
    private readonly IAuthenticationStore _authenticationStore;
    private readonly IAdoptionService _adoptionService;

    private string message = "";
    public string Message
    {
        get => message;
        set => SetField(ref message, value);
    }
    private AdoptionType selectedAdoptionType;
    public AdoptionType SelectedAdoptionType
    {
        get => selectedAdoptionType;
        set => SetField(ref selectedAdoptionType, value);
    }
    private ObservableCollection<AdoptionType> _adoptionTypes;
    public ObservableCollection<AdoptionType> AdoptionTypes
    {
        get
        {
            if (_adoptionTypes == null)
            {
                _adoptionTypes = new ObservableCollection<AdoptionType>(Enum.GetValues(typeof(AdoptionType)).Cast<AdoptionType>());
            }
            return _adoptionTypes;
        }
        set
        {
            if (_adoptionTypes != value)
            {
                _adoptionTypes = value;
                OnPropertyChanged(nameof(AdoptionTypes));
            }
        }
    }
    public AdoptionRequestViewModel(NavigationStore navigationStore, IAdoptionRequestService adoptionRequestService, 
        CurrentPostStore currentPostStore, IAuthenticationStore authenticationStore, IAdoptionService adoptionService)
    {
        NavigationStore = navigationStore;
        _adoptionRequestService = adoptionRequestService;
        ApplyCommand = new RelayCommand(_ => ApplyForAdoption());
        _currentPostStore = currentPostStore;
        _authenticationStore = authenticationStore;
        _adoptionService = adoptionService;
    }

    private void ApplyForAdoption()
    {
        if (Message == "")
        {
            MessageBox.Show("Message must be entered!");
            return;
        }
        if (IsAlreadyAdopted())
        {
            MessageBox.Show("This post is already adopted!");
            return;
        }

        var request = _adoptionRequestService.AddAdoptionRequest(SelectedAdoptionType,AdoptionRequestStatus.InReview, 
            _currentPostStore.CurrentPost, _authenticationStore.CurrentUserProfile.Email, Message);
        if (request != null)
        {
            MessageBox.Show("Request sent successfully!");
            NavigationStore.ClosePopup();
            AdoptionRequestsUpdated?.Invoke();
            return;
        }
        MessageBox.Show("Request already exists!");
    }

    private bool IsAlreadyAdopted()
    {
        var adoptions = _adoptionService.GetByPostId(_currentPostStore.CurrentPost.Id);
        foreach (var adoption in adoptions)
        {
            if (adoption.IsActive == true)
            {
                return true;
            }

        }
        return false;
    }
}

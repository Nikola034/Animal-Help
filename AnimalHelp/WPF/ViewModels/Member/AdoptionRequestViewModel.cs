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
        CurrentPostStore currentPostStore, IAuthenticationStore authenticationStore)
    {
        NavigationStore = navigationStore;
        _adoptionRequestService = adoptionRequestService;
        ApplyCommand = new RelayCommand(_ => ApplyForAdoption());
        _currentPostStore = currentPostStore;
        _authenticationStore = authenticationStore;
    }

    private void ApplyForAdoption()
    {
        if (Message == "")
        {
            MessageBox.Show("Message must be entered!");
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
}

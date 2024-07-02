using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.Utility.Navigation;
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
using System.Windows.Navigation;

namespace AnimalHelp.WPF.ViewModels.Member;

public class AdoptionsOverviewViewModel : ViewModelBase, INavigableDataContext
{
    private readonly IAdoptionService _adoptionService;
    private readonly IAdoptionRequestService _adoptionRequestService;
    private readonly IAuthenticationStore _authenticationStore;
    private readonly IPostService _postService;
    private readonly IPopupNavigationService _popupNavigationService;
    private readonly CurrentAdoptionStore _currentAdoptionStore;

    public ICommand CancelApplicationCommand { get; }
    public ICommand ReturnAnimalCommand { get; }




    public NavigationStore NavigationStore { get; }

    private ObservableCollection<AdoptionRequest> _appliedPosts;
    public ObservableCollection<AdoptionRequest> AppliedPosts { 
        get => _appliedPosts;
        set => SetField(ref _appliedPosts, value);
    }
    private ObservableCollection<AdoptionViewModel> _adoptions;
    public ObservableCollection<AdoptionViewModel> Adoptions {
        get => _adoptions;
        set => SetField(ref _adoptions, value);
    }
    
    

    public AdoptionsOverviewViewModel(NavigationStore navigationStore, IAdoptionRequestService adoptionRequestService,
        IAdoptionService adoptionService, IAuthenticationStore authenticationStore, IPostService postService, 
        IPopupNavigationService popupNavigationService, CurrentAdoptionStore currentAdoptionStore)
    {
        NavigationStore = navigationStore;
        _adoptionRequestService = adoptionRequestService;
        _adoptionService = adoptionService;
        _authenticationStore = authenticationStore;
        _postService = postService;
        _popupNavigationService = popupNavigationService;
        _currentAdoptionStore = currentAdoptionStore;
        AppliedPosts = new ObservableCollection<AdoptionRequest>();
        Adoptions = new ObservableCollection<AdoptionViewModel>();
        LoadAdoptions();
        LoadAppliedPosts();
        AdoptionRequestViewModel.AdoptionRequestsUpdated += OnAdoptionRequestsUpdated;

        CancelApplicationCommand = new RelayCommand<string>(CancelApplication);
        ReturnAnimalCommand = new RelayCommand<string>(ReturnAnimal);
    }

    private void ReturnAnimal(string obj)
    {
        _currentAdoptionStore.CurrentAdoption = _adoptionService.GetById(obj);
        _popupNavigationService.Navigate(Factories.ViewType.RateAnimal);

        // deactivating the current adoption
        _adoptionService.DeactivateAdoption(_currentAdoptionStore.CurrentAdoption.Id);
        LoadAdoptions();

        // changing the post state to available
        var post = _postService.GetById(_currentAdoptionStore.CurrentAdoption.PostId);
        post.State = PostState.AvailableToAdopt;
        _postService.Update(post.Id, post);

    }

    private void LoadAppliedPosts()
    {
        AppliedPosts.Clear();
        AppliedPosts = new ObservableCollection<AdoptionRequest>(
                                      _adoptionRequestService.GetByUserEmail(_authenticationStore.CurrentUserProfile.Email));
    }

    private void CancelApplication(string id)
    {
        var adoptionRequest = _adoptionRequestService.GetById(id);
        if (adoptionRequest != null)
        {
            _adoptionRequestService.DeleteAdoptionRequest(adoptionRequest.Id);
            LoadAppliedPosts();
            MessageBox.Show("Application canceled successfully");
            return;
        }
        MessageBox.Show("Application not found");
    }

    private void LoadAdoptions()
    {
        Adoptions.Clear();
        var userAdoptions = _adoptionService.GetByUserEmail(_authenticationStore.CurrentUserProfile.Email);
        foreach (var adoption in userAdoptions)
        {
            var post = _postService.GetById(adoption.PostId);
            if(post != null && adoption.IsActive == true)
            {
                Adoptions.Add(new AdoptionViewModel(post, adoption));
            }
        }
    }
    private void OnAdoptionRequestsUpdated()
    {
        LoadAppliedPosts();
    }
}

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AnimalHelp.Application.Services.DonationServices;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class CreateDonationViewModel : ViewModelBase, INavigableDataContext
{
    private readonly IDonationService _donationService;
    private readonly IClosePopupNavigationService _closePopupNavigationService;
    private readonly DonationStore _donationStore;
    
    public NavigationStore NavigationStore { get; }

    private string? _description;
    private string? _from;
    private bool _isAnonymous;
    private ObservableCollection<Post> _posts;
    private Post? _selectedPost;

    public string? Description
    {
        get => _description;
        set => SetField(ref _description, value);
    }

    public string? From
    {
        get => _from;
        set => SetField(ref _from, value);
    }

    public bool IsAnonymous
    {
        get => _isAnonymous;
        set => SetField(ref _isAnonymous, value);
    }

    public ObservableCollection<Post> Posts
    {
        get => _posts;
        set => SetField(ref _posts, value);
    }

    public Post? SelectedPost
    {
        get => _selectedPost;
        set => SetField(ref _selectedPost, value);
    }

    public ICommand SaveCommand { get; }

    public CreateDonationViewModel(IDonationService donationService, NavigationStore navigationStore, IPostService postService, IClosePopupNavigationService closePopupNavigationService, DonationStore donationStore)
    {
        _donationService = donationService;
        NavigationStore = navigationStore;
        _closePopupNavigationService = closePopupNavigationService;
        _donationStore = donationStore;
        SaveCommand = new RelayCommand(_ => Save(), _ => CanSave());
        _posts = new ObservableCollection<Post>(postService.GetAll());
    }

    private void Save()
    {
        _donationService.AddDonation(Description!, From!, IsAnonymous, SelectedPost);
        MessageBox.Show("Successfully added a donation.");
        _donationStore.UpdateDonationList();
        _closePopupNavigationService.Navigate(ViewType.CreateDonation);
    }

    private bool CanSave()
    {
        return Description != null && From != null;
    }
}
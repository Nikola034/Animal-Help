using System.Windows.Input;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Default;

public class MainViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }

    private readonly INavigationService _navigationService;
    private readonly IAnimalHelpViewModelFactory _viewModelFactory;
    
    public ICommand NavCommand { get; }
    public ICommand LoginCommand { get; }
    
    private ViewModelBase _currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        private set => SetField(ref _currentViewModel, value);
    }
    
    private SimpleFeedViewModel? _feedViewModel;
    private DonationsListViewModel? _donationsViewModel;

    public MainViewModel(NavigationStore navigationStore, INavigationService navigationService, IAnimalHelpViewModelFactory viewModelFactory)
    {
        NavigationStore = navigationStore;
        _navigationService = navigationService;
        _viewModelFactory = viewModelFactory;

        _currentViewModel = FeedViewModel;
        
        NavCommand = new RelayCommand(arg => OnNav(arg as string));
        LoginCommand = new RelayCommand(_ => OpenLogin());
    }
    
    private SimpleFeedViewModel FeedViewModel
    {
        get
        {
            _feedViewModel = (SimpleFeedViewModel)_viewModelFactory.CreateViewModel(ViewType.SimpleFeed);
            return _feedViewModel;
        }
    }
    
    private DonationsListViewModel DonationsViewModel
    {
        get
        {
            _donationsViewModel = (DonationsListViewModel)_viewModelFactory.CreateViewModel(ViewType.DonationList);
            return _donationsViewModel;
        }
    }

    private void OnNav(string? destination)
    {
        CurrentViewModel = destination switch
        {
            "feed" => FeedViewModel,
            "donations" => DonationsViewModel,
            _ => CurrentViewModel
        };
    }

    private void OpenLogin()
    {
        _navigationService.Navigate(ViewType.Login);
    }
}
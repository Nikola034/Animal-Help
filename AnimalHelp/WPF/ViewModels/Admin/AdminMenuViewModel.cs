using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Admin
{
    public class AdminMenuViewModel : ViewModelBase, INavigableDataContext
    {
        public RelayCommand NavCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;
        //private readonly Domain.Model.Admin _loggedInUser;
        private readonly IAnimalHelpViewModelFactory _viewModelFactory;




        private ViewModelBase currentViewModel;
        public NavigationStore NavigationStore { get; }

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            private set => SetField(ref currentViewModel, value);
        }
        //public AdminMenuViewModel(ILoginService loginService, INavigationService navigationService, NavigationStore navigationStore,
        //    IAuthenticationStore authenticationStore, IAnimalHelpViewModelFactory viewModelFactory)
        //{
        //    _loginService = loginService;
        //    _navigationService = navigationService;
        //    NavigationStore = navigationStore;
        //    NavCommand = new RelayCommand(execute => OnNav(execute as string));
        //    _viewModelFactory = viewModelFactory;
        //    //currentViewModel = RegisterViewModel;
        //    LogoutCommand = new RelayCommand(execute => Logout());
        //    //_loggedInUser = (Domain.Model.Admin)authenticationStore.CurrentUser.Person;
        //}

        public AdminMenuViewModel(NavigationStore navigationStore)
        {

            NavigationStore = navigationStore;
        }
        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {

                _ => CurrentViewModel
            };
        }

        private void Logout()
        {
            _loginService.LogOut();
            _navigationService.Navigate(ViewType.Login);
        }
    }
}

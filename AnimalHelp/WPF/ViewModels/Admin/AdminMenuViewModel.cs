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
        private readonly IAnimalHelpViewModelFactory _viewModelFactory;

        private VolunteerRegistrationViewModel? volunteerRegistrationViewModel;

        private VolunteerRegistrationViewModel VolunteerRegistrationViewModel
        {
            get
            {
                if (volunteerRegistrationViewModel == null)
                {
                    volunteerRegistrationViewModel = (VolunteerRegistrationViewModel)_viewModelFactory.CreateViewModel(ViewType.VolunteerTable);
                }

                return volunteerRegistrationViewModel;
            }
        }




        private ViewModelBase currentViewModel;
        public NavigationStore NavigationStore { get; }

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            private set => SetField(ref currentViewModel, value);
        }
        public AdminMenuViewModel(ILoginService loginService, INavigationService navigationService, NavigationStore navigationStore,
             IAnimalHelpViewModelFactory viewModelFactory)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            NavCommand = new RelayCommand(execute => OnNav(execute as string));
            _viewModelFactory = viewModelFactory;
            currentViewModel = VolunteerRegistrationViewModel;
            LogoutCommand = new RelayCommand(execute => Logout());

        }


        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {
                "volunteers" => VolunteerRegistrationViewModel,
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

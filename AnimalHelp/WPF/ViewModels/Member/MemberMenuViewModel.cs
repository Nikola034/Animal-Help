using AnimalHelp.Application.Services;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.WPF.ViewModels.Volounteer;
using System.Windows;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class MemberMenuViewModel : ViewModelBase, INavigableDataContext
    {
        public RelayCommand NavCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        private readonly ILoginService _loginService;
        private readonly IMemberService _memberService;
        private readonly IAuthenticationStore _authenticationStore;
        private readonly IMemberRepository _memberRepository;
        private readonly IVolunteeringApplicationService _volunteeringApplicationService;
        private readonly INavigationService _navigationService;
        private readonly IAnimalHelpViewModelFactory _viewModelFactory;


        public RelayCommand ApplyForVolunteeringCommand { get; set; }


        public NavigationStore NavigationStore { get; }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            private set => SetField(ref currentViewModel, value);
        }

        private CreatePostViewModel? createPostViewModel;

        private CreatePostViewModel CreatePostViewModel
        {
            get
            {
                if (createPostViewModel == null)
                {
                    createPostViewModel = (CreatePostViewModel)_viewModelFactory.CreateViewModel(ViewType.CreatePost);
                }

                return createPostViewModel;
            }
        }

        private FeedViewModel? feedViewModel;

        private FeedViewModel FeedViewModel
        {
            get
            {

                feedViewModel = (FeedViewModel)_viewModelFactory.CreateViewModel(ViewType.Feed);


                return feedViewModel;
            }
        }
        private CreateAnimalViewModel? createAnimalViewModel;
        private AdoptionsOverviewViewModel? adoptionsOverviewViewModel;


        private CreateAnimalViewModel CreateAnimalViewModel
        {
            get
            {
                if (createAnimalViewModel == null)
                {
                    createAnimalViewModel = (CreateAnimalViewModel)_viewModelFactory.CreateViewModel(ViewType.Animals);
                }

                return createAnimalViewModel;
            }
        }
        private AdoptionsOverviewViewModel AdoptionsOverviewViewModel
        {
            get
            {

                adoptionsOverviewViewModel = (AdoptionsOverviewViewModel)_viewModelFactory.CreateViewModel(ViewType.AdoptionsOverview);


                return adoptionsOverviewViewModel;
            }
        }

        public MemberMenuViewModel(IMemberService memberService, IAnimalHelpViewModelFactory viewModelFactory,
            INavigationService navigationService, NavigationStore navigationStore, IAuthenticationStore authenticationStore,
            IMemberRepository memberRepository, IVolunteeringApplicationService applicationService, ILoginService loginService)

        {
            _loginService = loginService;
            _memberService = memberService;
            _authenticationStore = authenticationStore;
            _memberRepository = memberRepository;
            _volunteeringApplicationService = applicationService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            NavCommand = new RelayCommand(execute => OnNav(execute as string));
            _viewModelFactory = viewModelFactory;
            currentViewModel = CreatePostViewModel;
            LogoutCommand = new RelayCommand(execute => Logout());

            ApplyForVolunteeringCommand = new RelayCommand(execute => ApplyForVolunteering());

        }

        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {
                "posts" => CreatePostViewModel,
                "feed" => FeedViewModel,
                "animals" => CreateAnimalViewModel,
                "adoptions" => AdoptionsOverviewViewModel,
                _ => CurrentViewModel
            };
        }

        private void Logout()
        {
            _loginService.LogOut();
            _navigationService.Navigate(ViewType.Login);
        }


        private void ApplyForVolunteering()
        {
            Domain.Model.Member member = _memberRepository.GetByEmail(_authenticationStore.CurrentUser.Person.Profile.Email);
            bool success = _volunteeringApplicationService.ApplyForVolunteering(member);
            if (!success)
            {
                MessageBox.Show("You already applied to be a volunteer, cant apply twice.", "Fail");
            }
            else
            {
                MessageBox.Show("Your application has been sent!", "Sucess");
            }

        }

    }
}

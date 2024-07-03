using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.WPF.ViewModels.Member;

namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class VolounteerMenuViewModel : ViewModelBase, INavigableDataContext
    {
        public RelayCommand NavCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        private readonly ILoginService _loginService;
        private readonly IMemberService _memberService;
        private readonly INavigationService _navigationService;



        private readonly IAnimalHelpViewModelFactory _viewModelFactory;



        public NavigationStore NavigationStore { get; }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            private set => SetField(ref currentViewModel, value);
        }


        private VotingViewModel? votingViewModel;

        private VotingViewModel VotingViewModel
        {
            get
            {
                votingViewModel = (VotingViewModel)_viewModelFactory.CreateViewModel(ViewType.VotingVolunteer);
                return votingViewModel;
            }
        }



        private CreatePostViewModel? createPostViewModel;

        private CreatePostViewModel CreatePostViewModel
        {
            get
            {
                createPostViewModel = (CreatePostViewModel)_viewModelFactory.CreateViewModel(ViewType.CreatePost);
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
        private ApprovePostsViewModel? approvePostsViewModel;


        private ApprovePostsViewModel ApprovePostsViewModel
        {
            get
            {

                approvePostsViewModel = (ApprovePostsViewModel)_viewModelFactory.CreateViewModel(ViewType.ApprovePosts);


                return approvePostsViewModel;
            }
        }
        private CreateAnimalViewModel? createAnimalViewModel;

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
        public VolounteerMenuViewModel(IMemberService memberService, IAnimalHelpViewModelFactory viewModelFactory, INavigationService navigationService, NavigationStore navigationStore, ILoginService loginService)

        {
            _memberService = memberService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            NavCommand = new RelayCommand(execute => OnNav(execute as string));
            _viewModelFactory = viewModelFactory;
            currentViewModel = CreatePostViewModel;
            _loginService = loginService;
            LogoutCommand = new RelayCommand(execute => Logout());



        }

        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {
                "posts" => CreatePostViewModel,
                "feed" => FeedViewModel,
                "approve" => ApprovePostsViewModel,
                "animals" => CreateAnimalViewModel,
                "voting" => VotingViewModel,
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

using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.WPF.ViewModels.Volounteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class MemberMenuViewModel : ViewModelBase, INavigableDataContext
    {
        public RelayCommand NavCommand { get; set; }

        private readonly IMemberService _memberService;
        private readonly INavigationService _navigationService;
        private readonly IAnimalHelpViewModelFactory _viewModelFactory;
        private readonly ILoginService _loginService;
        public RelayCommand LogoutCommand { get; set; }


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
                if (feedViewModel == null)
                {
                    feedViewModel = (FeedViewModel)_viewModelFactory.CreateViewModel(ViewType.Feed);
                }

                return feedViewModel;
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
        public MemberMenuViewModel(IMemberService memberService, IAnimalHelpViewModelFactory viewModelFactory, INavigationService navigationService, NavigationStore navigationStore, ILoginService loginService)
        {
            _memberService = memberService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            NavCommand = new RelayCommand(execute => OnNav(execute as string));
            _viewModelFactory = viewModelFactory;
            currentViewModel = CreatePostViewModel;
            LogoutCommand = new RelayCommand(execute => Logout());
            _loginService = loginService;

        }

        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {
                "posts" => CreatePostViewModel,
                "feed" => FeedViewModel,
                "animals" => CreateAnimalViewModel,
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

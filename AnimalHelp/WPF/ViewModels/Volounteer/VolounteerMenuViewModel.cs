using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.WPF.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class VolounteerMenuViewModel : ViewModelBase, INavigableDataContext
    {
        public RelayCommand NavCommand { get; set; }

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
        private ApprovePostsViewModel? approvePostsViewModel;

        private ApprovePostsViewModel ApprovePostsViewModel
        {
            get
            {
                if (approvePostsViewModel == null)
                {
                    approvePostsViewModel = (ApprovePostsViewModel)_viewModelFactory.CreateViewModel(ViewType.ApprovePosts);
                }

                return approvePostsViewModel;
            }
        }
        public VolounteerMenuViewModel(IMemberService memberService, IAnimalHelpViewModelFactory viewModelFactory, INavigationService navigationService, NavigationStore navigationStore)
        {
            _memberService = memberService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            NavCommand = new RelayCommand(execute => OnNav(execute as string));
            _viewModelFactory = viewModelFactory;
            currentViewModel = CreatePostViewModel;
        }

        private void OnNav(string? destination)
        {
            CurrentViewModel = destination switch
            {
                "posts" => CreatePostViewModel,
                "feed" => FeedViewModel,
                "approve" => ApprovePostsViewModel,
                _ => CurrentViewModel
            };
        }
    }
}

using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class FeedViewModel : ViewModelBase, INavigableDataContext
    {
        public ICommand ApplyForAdoptionCommand { get; }



        public ObservableCollection<Post> Posts { get; set; }

        private Post? _selectedItem;
        public Post? SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
        public NavigationStore NavigationStore { get; }


        private readonly CurrentPostStore _currentPostStore;
        private readonly IMemberService _memberService;
        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;
        private readonly IPopupNavigationService _popupNavigationService;
        public FeedViewModel(IAuthenticationStore authenticationStore, IMemberService memberService, IPostService postService, 
            INavigationService navigationService, NavigationStore navigationStore, IPopupNavigationService popupNavigationService,
            CurrentPostStore currentPostStore)
        {
            _authenticationStore = authenticationStore;
            _memberService = memberService;
            _postService = postService;
            _navigationService = navigationService;
            _popupNavigationService = popupNavigationService;

            NavigationStore = navigationStore;
            _currentPostStore = currentPostStore;

            ApplyForAdoptionCommand = new RelayCommand<string>(OpenAdoptionApplicationWindow);

            Posts = new();

            LoadPosts();
        }

        private void OpenAdoptionApplicationWindow(string postId)
        {
            _currentPostStore.CurrentPost = _postService.GetById(postId);
            _popupNavigationService.Navigate(Factories.ViewType.AdoptionRequest);
        }

        private void LoadPosts()
        {
            Posts.Clear();
            List<Domain.Model.Post> posts;

            posts = _postService.GetAll();

            if (_authenticationStore.CurrentUser.UserType == UserType.Member)
            {
                foreach (Domain.Model.Post post in posts)
                {
                    if (post.Status == PostStatus.Approved)
                    {
                        Posts.Add(post);
                    }
                }
            }
            else if (_authenticationStore.CurrentUser.UserType == UserType.Volunteer)
            {
                foreach (Domain.Model.Post post in posts)
                {
                    Posts.Add(post);
                }
            }
        }
    }
}

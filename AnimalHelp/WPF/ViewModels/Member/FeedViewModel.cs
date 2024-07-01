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

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class FeedViewModel : ViewModelBase, INavigableDataContext
    {
        public ObservableCollection<Post> Posts { get; set; }

        private Post? _selectedItem;
        public Post? SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
        public NavigationStore NavigationStore { get; }

        private readonly IMemberService _memberService;
        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;
        public FeedViewModel(IAuthenticationStore authenticationStore, IMemberService memberService, IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _authenticationStore = authenticationStore;
            _memberService = memberService;
            _postService = postService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;

            Posts = new();

            LoadPosts();
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

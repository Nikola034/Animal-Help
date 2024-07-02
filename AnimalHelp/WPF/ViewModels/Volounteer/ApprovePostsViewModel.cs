using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.Views.Volounteer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class ApprovePostsViewModel : ViewModelBase, INavigableDataContext
    {
        private readonly IMemberService _memberService;
        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;

        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }

        public bool selectingPost;
        private Post? _selectedItem;
        public Post? SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
        public RelayCommand ApprovePostCommand { get; }
        public RelayCommand DenyPostCommand { get; }

        public NavigationStore NavigationStore { get; }

        public ApprovePostsViewModel(IAuthenticationStore authenticationStore, IMemberService memberService, IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _authenticationStore = authenticationStore;
            _memberService = memberService;
            _postService = postService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            Posts = new();

            ApprovePostCommand = new RelayCommand(ApprovePost!);
            DenyPostCommand = new RelayCommand(DenyPost!);

            LoadPosts();
        }

        private void LoadPosts() 
        {
            Posts.Clear();
            List<Domain.Model.Post> posts;

            posts = _postService.GetAll();
            foreach (Domain.Model.Post post in posts)
            {
                if (post.Status == PostStatus.PendingApproval || post.Status == PostStatus.PendingUpdate)
                {
                    Posts.Add(post);
                }
            }
        }

        private void ApprovePost(object parameter)
        {
            if (SelectedItem == null)
                return;

            SelectedItem.Status = PostStatus.Approved;
            Domain.Model.Post post = _postService.Update(SelectedItem.Id, SelectedItem);
            Posts.Remove(SelectedItem);
        }

        private void DenyPost(object parameter)
        {
            if (SelectedItem == null) 
                return;

            if (SelectedItem.Status == PostStatus.PendingUpdate)
            {
                return;
            }

            SelectedItem.Status = PostStatus.Denied;
            Domain.Model.Post post = _postService.Update(SelectedItem.Id, SelectedItem);
            Posts.Remove(SelectedItem);
        }
    }
}

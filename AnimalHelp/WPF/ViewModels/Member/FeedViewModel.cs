using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows;
using System.Windows.Input;


namespace AnimalHelp.WPF.ViewModels.Member
{
    public class FeedViewModel : ViewModelBase, INavigableDataContext
    {

        public ICommand ApplyForAdoptionCommand { get; }



        public ObservableCollection<PostViewModel> Posts { get; set; }

        private Visibility _isCommentTextBoxVisible;
        public Visibility IsCommentTextBoxVisible
        {
            get => _isCommentTextBoxVisible;
            set
            {
                _isCommentTextBoxVisible = value;
                OnPropertyChanged(nameof(IsCommentTextBoxVisible));
            }
        }

        private Visibility _isApplyVisible;
        public Visibility IsApplyVisible
        {
            get => _isApplyVisible;
            set
            {
                _isApplyVisible = value;
                OnPropertyChanged(nameof(_isApplyVisible));
            }
        }


        private Visibility _isAddCommentVisible;
        public Visibility IsAddCommentVisible
        {
            get => _isAddCommentVisible;
            set
            {
                _isAddCommentVisible = value;
                OnPropertyChanged(nameof(_isAddCommentVisible));
            }
        }

        private Visibility _isCommentVisible;
        public Visibility IsCommentVisible
        {
            get => _isCommentVisible;
            set
            {
                _isCommentVisible = value;
                OnPropertyChanged(nameof(_isCommentVisible));
            }
        }

        private Visibility _isBackVisible;
        public Visibility IsBackVisible
        {
            get => _isBackVisible;
            set
            {
                _isBackVisible = value;
                OnPropertyChanged(nameof(_isBackVisible));
            }
        }

        private string _currentCommentText;
        public string CurrentCommentText
        {
            get => _currentCommentText;
            set
            {
                _currentCommentText = value;
                OnPropertyChanged(nameof(CurrentCommentText));
            }
        }

        private Visibility _areCommentsVisible;
        public Visibility AreCommentsVisible
        {
            get => _areCommentsVisible;
            set
            {
                _areCommentsVisible = value;
                OnPropertyChanged(nameof(_areCommentsVisible));
            }
        }

        public string LoggedUserEmail { get; private set; }

        private HashSet<string> _likedPosts { get; set; }

        public RelayCommand AddCommentCommand { get; }
        public RelayCommand ShowAddCommentCommand { get; }
        public RelayCommand BackCommand { get; }
        public RelayCommand LikeCommand { get; }


        public NavigationStore NavigationStore { get; }


        private readonly CurrentPostStore _currentPostStore;
        private readonly IMemberService _memberService;
        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;

        private readonly IAccountService _accountService;
        private readonly ICommentInfoService _commentInfoService;


        private readonly IPopupNavigationService _popupNavigationService;
        public FeedViewModel(ICommentInfoService commentInfoService, IAccountService accountService, IAuthenticationStore authenticationStore, IMemberService memberService, IPostService postService,
            INavigationService navigationService, NavigationStore navigationStore, IPopupNavigationService popupNavigationService,
            CurrentPostStore currentPostStore)

        {
            _authenticationStore = authenticationStore;
            _memberService = memberService;
            _postService = postService;
            _navigationService = navigationService;

            _accountService = accountService;
            _commentInfoService = commentInfoService;

            _popupNavigationService = popupNavigationService;


            NavigationStore = navigationStore;
            _currentPostStore = currentPostStore;

            ApplyForAdoptionCommand = new RelayCommand<string>(OpenAdoptionApplicationWindow);

            IsCommentTextBoxVisible = Visibility.Hidden;
            IsAddCommentVisible = Visibility.Hidden;
            IsCommentVisible = Visibility.Visible;
            IsBackVisible = Visibility.Hidden;
            AreCommentsVisible = Visibility.Collapsed;
            if (authenticationStore.UserType == UserType.Member) _isApplyVisible = Visibility.Visible;
            else _isApplyVisible = Visibility.Hidden;
            Posts = new();
            LoggedUserEmail = _authenticationStore.CurrentUser.Person.Profile.Email;
            _likedPosts = new();

            AddCommentCommand = new RelayCommand(AddComment);
            ShowAddCommentCommand = new RelayCommand(ShowAddComment);
            BackCommand = new RelayCommand(execute => GoBack());
            LikeCommand = new RelayCommand(LikeComment);
            LoadPosts();
        }



        private void ShowAddComment(object obj)
        {
            if (!(obj is PostViewModel)) return;
            IsAddCommentVisible = Visibility.Visible;
            IsCommentTextBoxVisible = Visibility.Visible;
            IsCommentVisible = Visibility.Hidden;
            IsBackVisible = Visibility.Visible;
            AreCommentsVisible = Visibility.Visible;
            ShowSelectedPost((PostViewModel)obj);
        }

        private void ShowSelectedPost(PostViewModel postViewModel)
        {
            Posts.Clear();
            Post post = _postService.GetById(postViewModel.Id);
            Posts.Add(new PostViewModel(post, _commentInfoService));
        }

        private void GoBack()
        {
            IsCommentTextBoxVisible = Visibility.Hidden;
            IsAddCommentVisible = Visibility.Hidden;
            IsCommentVisible = Visibility.Visible;
            IsBackVisible = Visibility.Hidden;
            AreCommentsVisible = Visibility.Collapsed;
            LoadPosts();
        }
        private void LikeComment(object obj)
        {
            if (obj is PostViewModel postViewModel)
            {
                if (_likedPosts.Contains(postViewModel.Id)) return;
                Post post = _postService.GetById(postViewModel.Id);
                post.Likes += 1;
                _postService.Update(post.Id, post);
                _likedPosts.Add(post.Id);
                if (AreCommentsVisible == Visibility.Visible)
                    ShowSelectedPost(postViewModel);
                else LoadPosts();
            }
        }
        private void AddComment(object obj)
        {
            if (obj is PostViewModel postViewModel && !string.IsNullOrWhiteSpace(CurrentCommentText))
            {
                Post post = _postService.GetById(postViewModel.Id);
                var userType = _authenticationStore.CurrentUser.UserType;
                string id;
                if (userType == UserType.Member)
                {
                    var member = (Domain.Model.Member)_authenticationStore.CurrentUser.Person;
                    id = member.Id;
                }
                else
                {
                    var volunteer = (Domain.Model.Volunteer)_authenticationStore.CurrentUser.Person;
                    id = volunteer.Id;
                }
                post.AddComment(new Comment
                (
                    id,
                    userType,
                    CurrentCommentText
                ));
                _postService.Update(post.Id, post);
                CurrentCommentText = string.Empty;
                ShowSelectedPost(postViewModel);
            }
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


            foreach (Domain.Model.Post post in posts)
            {
                if (post.Status == PostStatus.Approved)
                {
                    Posts.Add(new PostViewModel(post, _commentInfoService));
                }
            }


        }
    }
}
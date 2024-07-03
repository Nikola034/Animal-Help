using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Member;

namespace AnimalHelp.WPF.ViewModels.Default
{
    public class SimpleFeedViewModel : ViewModelBase, INavigableDataContext
    {
        public ObservableCollection<PostViewModel> Posts { get; set; }
        
        public NavigationStore NavigationStore { get; }
        
        private readonly IPostService _postService;

        private readonly IAccountService _accountService;


        public SimpleFeedViewModel(IAccountService accountService, IPostService postService, NavigationStore navigationStore)
        {
            _postService = postService;
            _accountService = accountService;
            
            NavigationStore = navigationStore;
            
            Posts = new();
            LoadPosts();
        }
        
        private void LoadPosts()
        {
            Posts.Clear();
            List<Post> posts;

            posts = _postService.GetAll();

            foreach (Post post in posts)
            {
                if (post.Status == PostStatus.Approved)
                {
                    Posts.Add(new PostViewModel(post, _accountService));
                }
            }
        }
    }
}
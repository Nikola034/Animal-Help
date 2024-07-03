using AnimalHelp.Application.Services.Post;
using AnimalHelp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public PostState State { get; set; }
        public DateTime PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }

        public ObservableCollection<CommentViewModel> Comments { get; set; }

        public List<Photo> Photos { get; set; }

        public Animal Animal { get; set; }

        private readonly ICommentInfoService _commentInfoService;

        public PostViewModel(Post post, ICommentInfoService commentInfoService)
        {
            Id = post.Id;
            State = post.State;
            PublishDate = post.PublishDate;
            Status = post.Status;
            Photos = post.Photos;
            Description = post.Description;
            Likes = post.Likes;
            Animal = post.Animal;
            _commentInfoService = commentInfoService;
            Comments = GetComments(post.Comments);
        }

        private ObservableCollection<CommentViewModel> GetComments(List<Comment> comments)
        {
            if (comments == null || comments.Count == 0) return new ObservableCollection<CommentViewModel> { };
            Dictionary<string, string> authorsEmails = _commentInfoService.GetAuthorsEmail(comments);
            ObservableCollection<CommentViewModel> commentViewModels = new ObservableCollection<CommentViewModel>();
            foreach (Comment comment in comments)
            {
                var commentViewModel = new CommentViewModel(authorsEmails[comment.AuthorId], comment.Content, comment.Created);
                commentViewModels.Add(commentViewModel);
            }
            return commentViewModels;
        }

    }
}

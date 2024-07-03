using System;

namespace AnimalHelp.WPF.ViewModels.Member
{
    public class CommentViewModel
    {
        public CommentViewModel(string authorEmail, string content, DateTime? created)
        {
            AuthorEmail = authorEmail;
            Content = content;
            Created = created;
        }

        public string AuthorEmail { get; }
        public string Content { get; }
        public DateTime? Created { get; }
    }
}

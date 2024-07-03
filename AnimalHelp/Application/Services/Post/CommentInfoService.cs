using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.Post
{
    public class CommentInfoService : ICommentInfoService
    {
        private readonly IAccountService _accountService;
        public CommentInfoService(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public Dictionary<string, string> GetAuthorsEmail(List<Domain.Model.Comment> comments)
        {
            if (comments == null || comments.Count == 0) return new Dictionary<string, string>();
            Dictionary<string, string> authorEmails = new();
            foreach (var comment in comments)
            {
                if (!authorEmails.ContainsKey(comment.AuthorId))
                    authorEmails.Add(comment.AuthorId, _accountService.GetEmailByUserId(comment.AuthorId, comment.UserType ?? UserType.Member));
            }
            return authorEmails;
        }
    }
}

using System.Collections.Generic;

namespace AnimalHelp.Application.Services.Post
{
    public interface ICommentInfoService
    {
        public Dictionary<string, string> GetAuthorsEmail(List<Domain.Model.Comment> comments);
    }
}

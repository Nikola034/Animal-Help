using System;

namespace AnimalHelp.Domain.Model
{
    public class Comment
    {


        public Comment(string authorId, UserType? userType, string content)
        {
            AuthorId = authorId;
            UserType = userType;
            Content = content;
            Created = DateTime.Now;

        }


        public string AuthorId { get; set; }
        public UserType? UserType { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }
    }
}

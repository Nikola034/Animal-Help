using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Post : IEntity
    {
        public string Id {  get; set; }
        public PostState State { get; set; }
        public DateTime PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }

        public List<Comment> Comments {  get; set; }
        
        public List<Photo> Photos { get; set; }

        public Animal Animal { get; set; }

        public Post()
        {
            Id = "0";
            State = PostState.AvailableToAdopt;
            PublishDate = DateTime.Now;
            Status = PostStatus.PendingApproval;
            Description = "";
            Likes = 0;
            Comments = new List<Comment>();
            Photos = new List<Photo>();
            Animal = new Animal();
        }

        public Post(string description, List<Comment> comments, List<Photo> photos, Animal animal)
        {
            Id = "0";
            State = PostState.AvailableToAdopt;
            PublishDate = DateTime.Now;
            Status = PostStatus.PendingApproval;
            Description = description;
            Likes = 0;
            Comments = comments;
            Photos = photos;
            Animal = animal;
        }

        public Post(string id, string description, List<Comment> comments, List<Photo> photos, Animal animal)
        {
            Id = id;
            State = PostState.AvailableToAdopt;
            PublishDate = DateTime.Now;
            Status = PostStatus.PendingApproval;
            Description = description;
            Likes = 0;
            Comments = comments;
            Photos = photos;
            Animal = animal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Post
    {
        public PostState State { get; set; }
        public DateTime PublishDate { get; set; }
        public PostStatus Status { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
    }
}

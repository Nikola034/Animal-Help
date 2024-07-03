using AnimalHelp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.WPF.ViewModels.Member;

public class AdoptionViewModel
{
    public string Id { get; set; }
    public string AnimalName { get; set; }
    public string AnimalBreed { get; set; }
    public string PostId { get; set; }
    public int AnimalRating { get; set; }
    public int MemberRating { get; set; }

    public AdoptionViewModel(Post post, Adoption adoption)
    {
        Id = adoption.Id;
        AnimalName = post.Animal.AnimalType.Name;
        AnimalBreed = post.Animal.AnimalType.Breed;
        PostId = adoption.PostId;
        AnimalRating = adoption.AnimalRating;
        MemberRating = adoption.MemberRating;

    }
}

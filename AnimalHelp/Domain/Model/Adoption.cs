using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model;

public class Adoption : IEntity
{
    public string Id { get; set; }

    public AdoptionType Type { get; set; }
    public bool IsActive { get; set; }
    public int AnimalRating { get; set; }
    public int MemberRating { get; set; }
    public string PostId { get; set; }
    public string UserEmail { get; set; }

    public Adoption()
    {
        Id = "";
        Type = AdoptionType.ForeverHome;
        IsActive = true;
        AnimalRating = 0;
        MemberRating = 0;
        PostId = "";
        UserEmail = "";
    }
    // Add new adoption sets ratings to 0
    public Adoption(AdoptionType type, bool isActive, string postid, string userEmail)
    {
        Id = "";
        Type = type;
        IsActive = isActive;
        AnimalRating = 0;
        MemberRating = 0;
        PostId = postid;
        UserEmail = userEmail;
    }
    public Adoption(AdoptionType type, bool isActive, int animalRating, int memberRating, string postid, string userEmail)
    {
        Id = "";
        Type = type;
        IsActive = isActive;
        AnimalRating = animalRating;
        MemberRating = memberRating;
        PostId = postid;
        UserEmail = userEmail;
    }

    public Adoption(string id, AdoptionType type, bool isActive, int animalRating, int memberRating, string postid, string userEmail)
    {
        Id = id;
        Type = type;
        IsActive = isActive;
        AnimalRating = animalRating;
        MemberRating = memberRating;
        PostId = postid;
        UserEmail = userEmail;
    }
    public void ChangeAdoptionState(bool isActive)
    {
        IsActive = isActive;
    }

    public void RateAnimal(int rating)
    {
        AnimalRating = rating;
    }
    public void RateMember(int rating)
    {
        MemberRating = rating;
    }


}

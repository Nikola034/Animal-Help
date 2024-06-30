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
    public string Postid { get; set; }
    public string UserId { get; set; }

    public Adoption()
    {
        Id = "";
        Type = AdoptionType.ForeverHome;
        IsActive = true;
        AnimalRating = 0;
        MemberRating = 0;
        Postid = "";
        UserId = "";
    }
    public Adoption(AdoptionType type, bool isActive, int animalRating, int memberRating, string postid, string userId)
    {
        Id = "";
        Type = type;
        IsActive = isActive;
        AnimalRating = animalRating;
        MemberRating = memberRating;
        Postid = postid;
        UserId = userId;
    }

    public Adoption(string id, AdoptionType type, bool isActive, int animalRating, int memberRating, string postid, string userId)
    {
        Id = id;
        Type = type;
        IsActive = isActive;
        AnimalRating = animalRating;
        MemberRating = memberRating;
        Postid = postid;
        UserId = userId;
    }
    public void ChangeAdoptionState(bool isActive)
    {
        IsActive = isActive;
    }


}

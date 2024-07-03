using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.AdoptionServices;

public interface IAdoptionService
{
    public List<Adoption> GetAll();

    public Adoption? GetById(string id);

    public Adoption AddAdoption(AdoptionType type, bool isActive, Domain.Model.Post? post, string userId);

    public Adoption UpdateAdoption(Adoption adoption);

    public void DeleteAdoption(string id);
    public List<Adoption> GetByUserEmail(string id);
    public List<Adoption> GetByPostId(string id);
    public List<Adoption> GetByType(AdoptionType type);
    public List<Adoption> GetActive();
    public void DeactivateAdoption(string id);

    public Adoption AcceptAdoptionRequest(AdoptionRequest request);

    public void RateAnimal(string id, int rating);
    public void RateMember(string id, int rating);

    public float GetMemberRating(string email);
}

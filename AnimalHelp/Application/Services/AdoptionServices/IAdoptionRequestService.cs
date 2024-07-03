using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.AdoptionServices;

public interface IAdoptionRequestService
{
    public List<AdoptionRequest> GetAll();

    public AdoptionRequest? GetById(string id);

    public AdoptionRequest AddAdoptionRequest(AdoptionType type, AdoptionRequestStatus status, Domain.Model.Post? post, string userId, string message);

    public AdoptionRequest UpdateAdoptionRequest(AdoptionRequest adoption);

    public void DeleteAdoptionRequest(string id);
    public List<AdoptionRequest> GetByUserEmail(string email);
    public List<AdoptionRequest> GetByPostId(string id);
    public List<AdoptionRequest> GetByType(AdoptionType type);
    public List<AdoptionRequest> GetByStatus(AdoptionRequestStatus status);
    public void UpdateAdoptionRequestStatus(string id, AdoptionRequestStatus status);
}

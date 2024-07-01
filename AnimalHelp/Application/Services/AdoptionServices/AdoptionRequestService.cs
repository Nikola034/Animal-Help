using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.AdoptionServices;

public class AdoptionRequestService : IAdoptionRequestService
{
    private readonly IAdoptionRequestRepository _adoptionRequestRepository;
    
    public AdoptionRequestService(IAdoptionRequestRepository adoptionRequestRepository)
    {
        _adoptionRequestRepository = adoptionRequestRepository;
    }

    public AdoptionRequest AddAdoptionRequest(AdoptionType type, AdoptionRequestStatus status, Domain.Model.Post post, string userId, string message)
    {
        if(userId == "" || message == "")
        {
            throw new ArgumentException("Description and donor required for donation");
        }
        return _adoptionRequestRepository.Add(new AdoptionRequest(message, status, type, post.Id, userId));
    }

    public void DeleteAdoptionRequest(string id)
    {
        if(id == "")
        {
            throw new ArgumentException("Adoption request id not provided!");
        }
        _adoptionRequestRepository.Delete(id);
    }

    public List<AdoptionRequest> GetAll()
    {
        return _adoptionRequestRepository.GetAll();
    }

    public AdoptionRequest? GetById(string id)
    {
        var request =  _adoptionRequestRepository.Get(id);
        if (request == null) return null;
        return request;
    }

    public List<AdoptionRequest> GetByPostId(string id)
    {
        return _adoptionRequestRepository.GetByPostId(id);
    }

    public List<AdoptionRequest> GetByStatus(AdoptionRequestStatus status)
    {
        return _adoptionRequestRepository.GetByStatus(status);
    }

    public List<AdoptionRequest> GetByType(AdoptionType type)
    {
        return _adoptionRequestRepository.GetByType(type);
    }

    public List<AdoptionRequest> GetByUserId(string id)
    {
        return _adoptionRequestRepository.GetByUserId(id);
    }

    public AdoptionRequest UpdateAdoptionRequest(AdoptionRequest adoption)
    {
        return _adoptionRequestRepository.Update(adoption.Id, adoption);
    }

    public void UpdateAdoptionRequestStatus(string id, AdoptionRequestStatus status)
    {
        var request = _adoptionRequestRepository.Get(id);
        if (request == null)
        {
            throw new ArgumentException("Invalid id provided, there is no adoption with given id");
        }
        request.ChangeRequestState(status);
        _adoptionRequestRepository.Update(request.Id, request);
    }
}

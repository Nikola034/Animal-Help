

using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System.Collections.Generic;

namespace AnimalHelp.Repositories.Json;

public class AdoptionRequestRepository : AutoIdRepository<AdoptionRequest>, IAdoptionRequestRepository
{
    public AdoptionRequestRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }

    public List<AdoptionRequest> GetByPostId(string id)
    {
        List<AdoptionRequest> requests = new();
        foreach(AdoptionRequest request in GetAll())
        {
            if(request.PostId == id)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<AdoptionRequest> GetByStatus(AdoptionRequestStatus status)
    {
        List<AdoptionRequest> requests = new();
        foreach (AdoptionRequest request in GetAll())
        {
            if (request.Status == status)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<AdoptionRequest> GetByType(AdoptionType type)
    {
        List<AdoptionRequest> requests = new();
        foreach (AdoptionRequest request in GetAll())
        {
            if (request.Type == type)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<AdoptionRequest> GetByUserId(string id)
    {
        List<AdoptionRequest> requests = new();
        foreach (AdoptionRequest request in GetAll())
        {
            if (request.UserId == id)
            {
                requests.Add(request);
            }
        }
        return requests;
    }
}

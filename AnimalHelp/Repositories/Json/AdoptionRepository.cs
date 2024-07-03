using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System.Collections.Generic;

namespace AnimalHelp.Repositories.Json;

public class AdoptionRepository : AutoIdRepository<Adoption>, IAdoptionRepository
{
    public AdoptionRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }

    public List<Adoption> GetActive()
    {
        List<Adoption> requests = new();
        foreach (Adoption request in GetAll())
        {
            if (request.IsActive)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<Adoption> GetByPostId(string id)
    {
        List<Adoption> requests = new();
        foreach (Adoption request in GetAll())
        {
            if (request.PostId == id)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<Adoption> GetByType(AdoptionType type)
    {
        List<Adoption> requests = new();
        foreach (Adoption request in GetAll())
        {
            if (request.Type == type)
            {
                requests.Add(request);
            }
        }
        return requests;
    }

    public List<Adoption> GetByUserEmail(string email)
    {
        List<Adoption> requests = new();
        foreach (Adoption request in GetAll())
        {
            if (request.UserEmail == email)
            {
                requests.Add(request);
            }
        }
        return requests;
    }
}

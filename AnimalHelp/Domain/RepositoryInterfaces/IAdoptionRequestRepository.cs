using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IAdoptionRequestRepository : IRepository<AdoptionRequest>
{
    public List<AdoptionRequest> GetByUserEmail(string email);
    public List<AdoptionRequest> GetByPostId(string id);
    public List<AdoptionRequest> GetByType(AdoptionType type);
    public List<AdoptionRequest> GetByStatus(AdoptionRequestStatus status);

}

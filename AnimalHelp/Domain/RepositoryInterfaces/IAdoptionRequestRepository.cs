using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Domain.RepositoryInterfaces;

internal interface IAdoptionRequestRepository : IRepository<AdoptionRequest>
{
    public List<AdoptionRequest> GetByUserId(string id);
    public List<AdoptionRequest> GetByPostId(string id);
    public List<AdoptionRequest> GetByType(AdoptionType type);
    public List<AdoptionRequest> GetByStatus(AdoptionRequestStatus status);

}

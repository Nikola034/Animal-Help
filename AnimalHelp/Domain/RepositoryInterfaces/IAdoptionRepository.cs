using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IAdoptionRepository: IRepository<Adoption>
{
    public List<Adoption> GetByUserId(string id);
    public List<Adoption> GetByPostId(string id);
    public List<Adoption> GetByType(AdoptionType type);
    public List<Adoption> GetActive();
}

using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json
{
    public class AdoptionCentreRepository : AutoIdRepository<AdoptionCentre>, IAdoptionCentreRepository
    {
        public AdoptionCentreRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
        {
        }
    }
}

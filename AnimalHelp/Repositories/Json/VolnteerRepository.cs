using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class VolnteerRepository : AutoIdRepository<Volunteer>, IVolnteerRepository
{
    public VolnteerRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }
}
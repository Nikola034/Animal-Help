using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class VolunteerRepository : AutoIdRepository<Volunteer>, IVolunteerRepository
{
    public VolunteerRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }
}
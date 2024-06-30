using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(string filepath) : base(filepath)
    {
    }

    protected override string GetId(Profile profile)
    {
        return profile.Email;
    }
}
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class VolunteerRepository : AutoIdRepository<Volunteer>, IVolunteerRepository
{
    public VolunteerRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }
    public Volunteer GetByEmail(string email)
    {
        var volunteers = Load();
        foreach (Volunteer volunteer in volunteers.Values)
        {
            if (volunteer.Profile == null) continue;
            if (volunteer.Profile.Email == email) return volunteer;
        }

        return null;
    }

    public void SaveNewVolunteer(Volunteer volunteer)
    {
        var volunteers = Load();
        volunteers.Add(volunteer.Id, volunteer);
        Save(volunteers);
    }


}
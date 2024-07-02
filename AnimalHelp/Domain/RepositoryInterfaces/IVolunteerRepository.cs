using AnimalHelp.Domain.Model;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IVolunteerRepository : IRepository<Volunteer>
{
    public Volunteer GetByEmail(string email);
    public void SaveNewVolunteer(Volunteer volunteer);
}
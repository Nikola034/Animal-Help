using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users.Volunteer;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IVoteRepository : IRepository<Vote>
{
    public Vote GetVote(string volunteeringApplicationId, string volunteerId);

}
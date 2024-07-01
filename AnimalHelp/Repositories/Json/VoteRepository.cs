using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users.Volunteer;
using AnimalHelp.Domain.RepositoryInterfaces;
using System.Windows.Documents;

namespace AnimalHelp.Repositories.Json;

public class VoteRepository : AutoIdRepository<Vote>, IVoteRepository
{
    public VoteRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }

    public Vote GetVote(string volunteeringApplicationId, string volunteerId)
    {
        var votes = Load();
        foreach (var vote in votes.Values)
        {
            if (vote.VolunteerId == volunteerId && vote.VolunteeringAplicationId == volunteeringApplicationId)
            {
                return vote;
            }

        }
        return null;

    }

}
using AnimalHelp.Domain.Model;
using static AnimalHelp.Domain.Model.Users.Volunteer.Vote;

namespace AnimalHelp.Application.Services;

public interface IVolunteeringApplicationService
{
    public bool ApplyForVolunteering(Member member);

    public bool VoteForVolunteeringApplication(string votingVolunteerId, string applicationId, VoteVerdict verdict);
}

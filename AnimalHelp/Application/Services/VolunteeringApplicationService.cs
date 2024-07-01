using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Users.Volunteer;
using AnimalHelp.Domain.RepositoryInterfaces;

using static AnimalHelp.Domain.Model.Users.Volunteer.Vote;

namespace AnimalHelp.Application.Services;

public class VolunteeringApplicationService: IVolunteeringApplicationService
{
    private readonly IAccountService _accountService;
    private readonly IVoteRepository _voteRepository;
    private readonly IVolunteeringApplicationRepository _volunteeringApplicationRepository;
    private readonly IVolunteerRepository _volunteerRepository;


    public VolunteeringApplicationService(IAccountService accountService, IVoteRepository voteRepository, IVolunteeringApplicationRepository volunteeringApplicationRepository, IVolunteerRepository volunteerRepository)
    {
        _accountService = accountService;
        _voteRepository = voteRepository;
        _volunteeringApplicationRepository = volunteeringApplicationRepository;
        _volunteerRepository = volunteerRepository;
    }

    public bool ApplyForVolunteering(Member member)
    {
        if(_volunteeringApplicationRepository.Get(member) != null)
        {
            return false;       //cant apply twice
        }

        VolunteeringApplication application = new VolunteeringApplication(member);
        _volunteeringApplicationRepository.Add(application);
        return true;
    }

    public bool VoteForVolunteeringApplication(string votingVolunteerId, string applicationId, VoteVerdict verdict)
    {
        if(_voteRepository.GetVote(applicationId, votingVolunteerId) != null)
        {
            return false;   //cant vote twice
        }

        Vote vote = new Vote(applicationId, votingVolunteerId, verdict);
        _voteRepository.Add(vote);


        VolunteeringApplication application = _volunteeringApplicationRepository.Get(applicationId);
        application.AddVote(verdict);
        _volunteeringApplicationRepository.Update(applicationId, application);
        if(application.State == VolunteeringApplication.ApplicationState.Accepted)
        {
            Member member = application.Applicant;
            _accountService.DeleteMember(member);
            Volunteer volunteer = new Volunteer(member.Name, member.Surname, member.BirthDate, member.Gender, member.PhoneNumber);
            volunteer.Profile = member.Profile;
            _volunteerRepository.SaveNewVolunteer(volunteer);
        }
        return true;
    }



}

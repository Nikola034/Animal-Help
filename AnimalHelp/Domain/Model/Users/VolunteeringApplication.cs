using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model.Users;

public class VolunteeringApplication : IEntity
{
    public string Id { get; set; }
    public Member Applicant { get; set; }
    public int PositiveVotes { get; set; }
    public int NegativeVotes { get; set; }

    public ApplicationState State { get; set; }

    public VolunteeringApplication()
    {

    }


    public VolunteeringApplication(Member applicant)
    {
        Applicant = applicant;
        State = ApplicationState.Pending;
    }

    public VolunteeringApplication(Member applicant, int positiveVotes, int negativeVotes)
    {
        Applicant = applicant;
        PositiveVotes = positiveVotes;
        NegativeVotes = negativeVotes;
        State = ApplicationState.Pending;
    }


    public VolunteeringApplication(Member applicant, int positiveVotes, int negativeVotes, ApplicationState state)
    {
        Applicant = applicant;
        PositiveVotes = positiveVotes;
        NegativeVotes = negativeVotes;
        State = state;  
    }
    public VolunteeringApplication(string id, Member applicant, int positiveVotes, int negativeVotes, ApplicationState state)
    {
        Id = id;
        Applicant = applicant;
        PositiveVotes = positiveVotes;
        NegativeVotes = negativeVotes;
        State = state;
    }

    public void AddVote(Vote.VoteVerdict verdict)
    {
        if (verdict == Vote.VoteVerdict.Positive) PositiveVotes++;
        else NegativeVotes++;
        if (PositiveVotes >= Constants.requiredVotesForApproval) State = ApplicationState.Accepted;
        if (NegativeVotes >= Constants.requiredVotesForDenial) State = ApplicationState.Denied;
    }


    public enum ApplicationState{
        Accepted,
        Denied,
        Pending
    }

}

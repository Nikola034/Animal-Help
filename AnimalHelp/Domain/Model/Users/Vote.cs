using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model.Users;

public class Vote : IEntity
{
    public string Id { get; set; }
    public string VolunteeringAplicationId { get; set; }
    public string VolunteerId { get; set; }
    public VoteVerdict Verdict { get; set; }

    public Vote()
    {

    }
    public Vote(string id, string volunteeringAplicationId, string volunteerId, VoteVerdict verdict)
    {
        Id = id;
        VolunteeringAplicationId = volunteeringAplicationId;
        VolunteerId = volunteerId;
        Verdict = verdict;
    }
    public Vote(string volunteeringAplicationId, string volunteerId, VoteVerdict verdict)
    {
        Id = "";
        VolunteeringAplicationId = volunteeringAplicationId;
        VolunteerId = volunteerId;
        Verdict = verdict;
    }

    public enum VoteVerdict {
        Positive,
        Negative
    }


}

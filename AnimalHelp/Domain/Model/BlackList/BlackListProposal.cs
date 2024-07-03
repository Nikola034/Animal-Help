using System;
using System.Collections.Generic;

namespace AnimalHelp.Domain.Model.BlackList;

public class BlackListProposal : IEntity
{
    public string Id { get; set; }
    public string CandidateId { get; set; }
    public bool IsActive { get; set; }
    public List<Message> Messages { get; set; }

    public BlackListProposal(string id, string candidateId, bool isActive, List<Message> messages)
    {
        Id = id;
        CandidateId = candidateId;
        IsActive = isActive;
        Messages = messages;
    }
    
    public BlackListProposal(string candidateId) : this("", candidateId, true, [])
    {
    }

    public BlackListProposal() : this("", "", false, new())
    {
    }

    public Message AddMessage(string content, Volunteer author)
    {
        var message = new Message(author.Id, content, DateTime.Now);
        Messages.Add(message);
        return message;
    }

    public void Accept()
    {
        if (!IsActive) return;
        IsActive = false;
        // Candidate.IsBlackListed = true;
        // Candidate.Profile.IsActive = false;
    }

    public void Reject()
    {
        IsActive = false;
    }
}
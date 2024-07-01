using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model;

public class AdoptionRequest : IEntity
{
    public string Id { get; set; }
    public string Message { get; set; }
    public AdoptionRequestStatus Status { get; set; }
    public AdoptionType Type { get; set; }
    public string PostId { get; set; }
    public string UserId { get; set; }

    public AdoptionRequest()
    {
        Id = "";
        Message = "";
        Status = AdoptionRequestStatus.InReview;
        Type = AdoptionType.ForeverHome;
        PostId = "";
        UserId = "";
    }
    public AdoptionRequest(string message, AdoptionRequestStatus status, AdoptionType type, string postId, string userId)
    {
        Id = "";
        Message = message;
        Status = status;
        Type = type;
        PostId = postId;
        UserId = userId;
    }
    public AdoptionRequest(string id, string message, AdoptionRequestStatus status, AdoptionType type, string postId, string userId)
    {
        Id = id;
        Message = message;
        Status = status;
        Type = type;
        PostId = postId;
        UserId = userId;
    }
    public void ChangeRequestState(AdoptionRequestStatus status)
    {
        Status = status;
    }



}

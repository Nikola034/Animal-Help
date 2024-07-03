using System;

namespace AnimalHelp.Domain.Model.Donations;

public class Donation(string id, DateTime dateTime, string description, string from, bool isAnonymous, string? postId = null) : IEntity
{
    public string Id { get; set; } = id;
    public DateTime DateTime { get; set; } = dateTime;
    public string Description { get; set; } = description;
    public string From { get; set; } = from;
    public bool IsAnonymous { get; set; } = isAnonymous;
    public string? PostId { get; set; } = postId;

    public Donation() : this("", DateTime.MinValue, "", "", false)
    {
    }

    public Donation(DateTime dateTime, string description, string from, bool isAnonymous, string? postId = null)
        : this("", dateTime, description, from, isAnonymous, postId)
    {
    }
}
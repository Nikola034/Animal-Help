namespace AnimalHelp.Domain.Model;

public class Donation(string id, string description, string from, bool isAnonymous, string? postId = null) : IEntity
{
    public string Id { get; set; } = id;
    public string Description { get; set; } = description;
    public string From { get; set; } = from;
    public bool IsAnonymous { get; set; } = isAnonymous;
    public string? PostId { get; set; } = postId;

    public Donation() : this("", "", "", false)
    {
    }

    public Donation(string description, string from, bool isAnonymous, string? postId = null)
        : this("", description, from, isAnonymous, postId)
    {
    }
}
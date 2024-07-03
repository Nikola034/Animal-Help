using System;

namespace AnimalHelp.Domain.Model.BlackList;

public class Message(string authorId, string content, DateTime time)
{
    public string AuthorId { get; set; } = authorId;
    public string Content { get; set; } = content;
    public DateTime Time { get; set; } = time;
}
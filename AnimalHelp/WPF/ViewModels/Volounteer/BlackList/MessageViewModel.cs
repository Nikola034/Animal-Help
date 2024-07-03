using System;
using AnimalHelp.Domain.Model.BlackList;

namespace AnimalHelp.WPF.ViewModels.Volounteer.BlackList;

public class MessageViewModel(Message message, string author)
{
    public string Content { get; } = message.Content;
    public string Author { get; } = author;
    public DateTime Time { get; } = message.Time;
}
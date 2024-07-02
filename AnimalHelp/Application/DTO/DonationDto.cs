using System;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.Application.DTO;

public class DonationDto(Donation donation, Post? post)
{
    public string Id { get; set; } = donation.Id;
    public DateTime DateTime { get; set; } = donation.DateTime;
    public string Description { get; set; } = donation.Description;
    public string From { get; set; } = donation.From;
    public bool IsAnonymous { get; set; } = donation.IsAnonymous;
    public Post? Post { get; set; } = post;
}
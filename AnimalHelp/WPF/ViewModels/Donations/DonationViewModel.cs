using System;
using AnimalHelp.Application.DTO;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class DonationViewModel(DonationDto donation)
    : IDateTimeSortable
{
    public DateTime DateTime { get; } = donation.DateTime;
    public string From { get; } = donation.IsAnonymous ? "" : donation.From;
    public string Description { get; } = donation.Description;
    public string PostDescription { get; } = donation.Post?.Animal.Name ?? "";
}
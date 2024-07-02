using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class DonationViewModel(string description, string from, string postDescription)
{
    public string Description { get; } = description;
    public string From { get; } = from;
    public string PostDescription { get; } = postDescription;

    public static DonationViewModel FromDonation(Donation donation, Post? post)
    {
        return new DonationViewModel(
            donation.IsAnonymous ? "" : donation.From,
            donation.Description,
            donation.PostId == null ? "" : post!.Animal.Id
        );
    }
}
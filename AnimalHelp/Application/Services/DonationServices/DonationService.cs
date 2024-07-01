using System;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Application.Services.DonationServices;

public class DonationService(IDonationRepository donationRepository) : IDonationService
{
    public Donation AddDonation(string description, string from, bool isAnonymous, Domain.Model.Post? post)
    {
        if (description == "" || from == "")
            throw new ArgumentException("Description and donor required for donation");
        return donationRepository.Add(new Donation(description, from, isAnonymous, post?.Id));
    }
}
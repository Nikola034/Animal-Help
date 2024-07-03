using System;
using System.Collections.Generic;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Domain.Model.Donations;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Application.Services.DonationServices;

public class DonationService(IDonationRepository donationRepository, IPostService postService)
    : IDonationService
{
    public Donation AddDonation(string description, string from, bool isAnonymous, Domain.Model.Post? post)
    {
        if (description == "" || from == "")
            throw new ArgumentException("Description and donor required for donation");
        return donationRepository.Add(new Donation(DateTime.Now, description, from, isAnonymous, post?.Id));
    }

    public List<DonationDto> GetAll()
    {
        var donations = new List<DonationDto>();
        foreach (var donation in donationRepository.GetAll())
        {
            donations.Add(new DonationDto(
                donation,
                donation.PostId == null ? null : postService.GetById(donation.PostId)
            ));
        }

        return donations;
    }
}
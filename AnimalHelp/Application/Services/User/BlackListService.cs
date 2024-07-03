using System;
using System.Collections.Generic;
using System.Linq;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.BlackList;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Application.Services.User;

public class BlackListService(
    IAccountService accountService, 
    IBlackListProposalRepository blackListProposalRepository
    ) : IBlackListService
{
    private readonly IAccountService _accountService = accountService;
    private readonly IBlackListProposalRepository _blackListProposalRepository = blackListProposalRepository;

    public List<UserDto> GetBlackListedUsers() => _accountService.GetAllUsers()
        .Where(userDto => userDto.Person?.IsBlackListed ?? false).ToList();
    
    public List<UserDto> GetActiveUsers()
    {
        return _accountService.GetAllUsers()
            .Where(userDto => !userDto.Person?.IsBlackListed ?? false)
            .Where(userDto => !HasBlackListRequest(userDto.Person?.Id))
            .ToList();
    }

    public BlackListProposalDto ProposeForBlackList(Domain.Model.User user)
    {
        if (user.IsBlackListed)
            throw new ArgumentException("User already blacklisted.");
        var proposal = _blackListProposalRepository.Add(new BlackListProposal(user.Id));
        return new BlackListProposalDto(
            proposal,
            _accountService.GetUserById(proposal.CandidateId)
        );
    }

    public List<BlackListProposalDto> GetBlackListProposals()
    {
        return _blackListProposalRepository.GetAll().Select(proposal =>
            new BlackListProposalDto(
                proposal, 
                _accountService.GetUserById(proposal.CandidateId)
                )
            )
            .ToList();
    }

    public List<BlackListProposalDto> GetActiveBlackListProposals()
        => GetBlackListProposals().Where(dto => dto.Proposal.IsActive).ToList();
    
    public Message AddMessageToDiscussion(BlackListProposal proposal, Volunteer author, string content)
    {
        var message = proposal.AddMessage(content, author);
        _blackListProposalRepository.Update(proposal.Id, proposal);
        return message;
    }

    public void AcceptProposal(BlackListProposal proposal)
    {
        if (!proposal.IsActive)
            throw new ArgumentException("Cannot accept inactive proposal.");
        proposal.Accept();
        var user = _accountService.GetUserById(proposal.CandidateId);
        if (user.Person == null)
            return;
        user.Person.BlackList();
        user.Person.Profile.IsActive = false;
        _accountService.UpdateUser(user);
        _blackListProposalRepository.Update(proposal.Id, proposal);
    }

    public void RejectProposal(BlackListProposal proposal)
    {
        if (!proposal.IsActive)
            throw new ArgumentException("Cannot reject inactive proposal.");
        proposal.Reject();
        _blackListProposalRepository.Update(proposal.Id, proposal);
    }

    private bool HasBlackListRequest(string? userId)
    {
        if (userId == null)
            return false;
        return GetActiveBlackListProposals().Any(dto => dto.Proposal.CandidateId == userId);
    }

    
}
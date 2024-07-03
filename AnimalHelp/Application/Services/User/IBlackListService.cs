using System.Collections.Generic;
using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.BlackList;

namespace AnimalHelp.Application.Services.User;

public interface IBlackListService
{
    public List<UserDto> GetBlackListedUsers();
    public List<UserDto> GetActiveUsers();
    public BlackListProposalDto ProposeForBlackList(Domain.Model.User user);
    public List<BlackListProposalDto> GetBlackListProposals();
    public List<BlackListProposalDto> GetActiveBlackListProposals();
    public Message AddMessageToDiscussion(BlackListProposal proposal, Volunteer author, string content);
    public void AcceptProposal(BlackListProposal proposal);
    public void RejectProposal(BlackListProposal proposal);
}
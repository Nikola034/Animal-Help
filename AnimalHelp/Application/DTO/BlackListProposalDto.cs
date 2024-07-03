using AnimalHelp.Domain.Model.BlackList;

namespace AnimalHelp.Application.DTO;

public class BlackListProposalDto(BlackListProposal proposal, UserDto user)
{
    public BlackListProposal Proposal { get; } = proposal;
    public UserDto User { get; } = user;
}
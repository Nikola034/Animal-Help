using AnimalHelp.Application.DTO;

namespace AnimalHelp.WPF.ViewModels.Volounteer.BlackList;

public class BlackListProposalViewModel(UserViewModel user, BlackListProposalDto proposal)
{
    public UserViewModel User { get; } = user;
    public BlackListProposalDto Proposal { get; } = proposal;
}
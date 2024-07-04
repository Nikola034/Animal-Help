using System;
using AnimalHelp.Application.DTO;

namespace AnimalHelp.Application.Stores;

public class CurrentBlackListProposalStore
{
    private BlackListProposalDto? _blackListProposalDto;
    public BlackListProposalDto? BlackListProposalDto
    {
        get => _blackListProposalDto;
        set
        {
            _blackListProposalDto = value;
            if(value == null)
                CurrentProposalCleared?.Invoke();
        }
    }

    public event Action? CurrentProposalCleared;
}
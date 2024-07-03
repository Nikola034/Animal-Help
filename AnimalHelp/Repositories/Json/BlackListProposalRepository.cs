using AnimalHelp.Domain.Model.BlackList;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class BlackListProposalRepository(string filepath, string lastIdFilePath)
    : AutoIdRepository<BlackListProposal>(filepath, lastIdFilePath), IBlackListProposalRepository;
using AnimalHelp.Domain.Model.Donations;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class DonationRepository(string filepath, string lastIdFilePath)
    : AutoIdRepository<Donation>(filepath, lastIdFilePath), IDonationRepository;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class MemberRepository : AutoIdRepository<Member>, IMemberRepository
{
    public MemberRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }
}
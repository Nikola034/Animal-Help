using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class MemberRepository : AutoIdRepository<Member>, IMemberRepository
{
    public MemberRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
    {
    }

    public Member GetByEmail(string email)
    {
        var members = Load();
        foreach(Member member in members.Values)
        {
            if(member.Profile == null) continue;
            if(member.Profile.Email == email) return member;
        }

        return null;
    }

}
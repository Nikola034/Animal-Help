using System.Collections.Generic;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IMemberRepository : IRepository<Member>
{
    public Member GetByEmail(string email);
}
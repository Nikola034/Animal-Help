using AnimalHelp.Domain.Model;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IAdminRepository : IRepository<Admin>
{
    public Admin GetByEmail(string email);

}

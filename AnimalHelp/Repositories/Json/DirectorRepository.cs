using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;


namespace AnimalHelp.Repositories.Json
{
    public class AdminRepository : AutoIdRepository<Admin>, IAdminRepository
    {
        public AdminRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
        {
        }
    }
}
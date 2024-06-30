using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;


namespace AnimalHelp.Repositories.Json
{
    public class AdminRepository : AutoIdRepository<Admin>, IAdminRepository
    {
        public AdminRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath)
        {
        }

        public Admin GetByEmail(string email)
        {
            var admins = Load();
            foreach (Admin admin in admins.Values)
            {
                if (admin.Profile == null) continue;
                if (admin.Profile.Email == email) return admin;
            }

            return null;
        }
    }
}
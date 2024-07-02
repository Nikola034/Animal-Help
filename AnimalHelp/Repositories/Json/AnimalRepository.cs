using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Repositories.Json
{
    public class AnimalRepository : AutoIdRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(string filepath, string lastIdFilePath) : base(filepath, lastIdFilePath) { }
    }
}

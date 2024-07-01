using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Application.Services.AdoptionCentre
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Add(Domain.Model.Animal animal)
        {
            _animalRepository.Add(animal);
        }

        public void Delete(string id)
        {
            _animalRepository.Delete(id);
        }

        public List<Domain.Model.Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public Domain.Model.Animal GetById(string id)
        {
            return _animalRepository.Get(id);
        }

        public List<Domain.Model.Animal> GetByIds(List<string> ids)
        {
            return _animalRepository.Get(ids);
        }

        public Domain.Model.Animal Update(string id, Domain.Model.Animal animal)
        {
            return _animalRepository.Update(id, animal);
        }
    }
}

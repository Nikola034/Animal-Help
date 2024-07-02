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
        private readonly IPostRepository _postRepository;

        public AnimalService(IAnimalRepository animalRepository, IPostRepository postRepository)
        {
            _animalRepository = animalRepository;
            _postRepository = postRepository;
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

        public List<Domain.Model.Animal> GetAnimalsWithoutPost()
        {
            List<Domain.Model.Animal> animals = new List<Animal>(); 
            foreach (var animal in _animalRepository.GetAll())
            {
                var x = 0;
                foreach(var post in _postRepository.GetAll())
                {
                    if(post.Animal.Id == animal.Id)
                    {
                        x++;
                    }
                }
                if(x == 0)
                {
                    animals.Add(animal);
                }
            }
            return animals;
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

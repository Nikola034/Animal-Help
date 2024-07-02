using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Application.Services.AdoptionCentre
{
    public interface IAnimalService
    {
        public List<Domain.Model.Animal> GetAll();

        public Domain.Model.Animal GetById(string id);

        public List<Domain.Model.Animal> GetByIds(List<string> ids);

        public void Add(Domain.Model.Animal animal);

        public void Delete(string id);

        public Domain.Model.Animal Update(string id, Domain.Model.Animal animal);

        public List<Domain.Model.Animal> GetAnimalsWithoutPost();
    }
}

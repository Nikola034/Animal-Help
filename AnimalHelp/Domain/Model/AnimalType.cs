using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class AnimalType : IEntity
    {
        public AnimalType() { }
        public AnimalType(string name, string breed)
        {
            Id = "0";
            Name = name;
            Breed = breed;
        }
        public AnimalType(string id, string name, string breed)
        {
            Id = id;
            Name = name;
            Breed = breed;
        }

        public string Id {  get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Breed}";
        }
    }
}

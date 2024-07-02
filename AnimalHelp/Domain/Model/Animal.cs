using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Animal : IEntity
    {
        public Animal() { }
        public Animal(int birthYear, string name, string description, Location foundLocation, Location currentLocation, HealthCondition healthCondition, AnimalType animalType)
        {
            Id = "0";
            Name = name;
            Description = description;
            BirthYear = birthYear;
            FoundLocation = foundLocation;
            CurrentLocation = currentLocation;
            HealthCondition = healthCondition;
            AnimalType = animalType;
        }
        public Animal(string id, int birthYear, string name, string description, Location foundLocation, Location currentLocation, HealthCondition healthCondition, AnimalType animalType)
        {
            Id = id;
            BirthYear = birthYear;
            Name = name;
            Description = description;
            FoundLocation = foundLocation;
            CurrentLocation = currentLocation;
            HealthCondition = healthCondition;
            AnimalType = animalType;
        }

        public string Id {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public int BirthYear { get; set; }
        public Location FoundLocation { get; set; }
        public Location CurrentLocation {  get; set; }
        public HealthCondition HealthCondition { get; set; }
        public AnimalType AnimalType { get; set; }

        public override string ToString()
        {
            return AnimalType.Name + ", " + AnimalType.Breed + ", " + this.Name + ", " + this.Description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Animal : IEntity
    {
        public Animal() { }
        public Animal(int birthYear, Location foundLocation, Location currentLocation, HealthCondition healthCondition, AnimalType animalType)
        {
            Id = "0";
            BirthYear = birthYear;
            FoundLocation = foundLocation;
            CurrentLocation = currentLocation;
            HealthCondition = healthCondition;
            AnimalType = animalType;
        }
        public Animal(string id, int birthYear, Location foundLocation, Location currentLocation, HealthCondition healthCondition, AnimalType animalType)
        {
            Id = id;
            BirthYear = birthYear;
            FoundLocation = foundLocation;
            CurrentLocation = currentLocation;
            HealthCondition = healthCondition;
            AnimalType = animalType;
        }

        public string Id {  get; set; }
        public int BirthYear { get; set; }
        public Location FoundLocation { get; set; }
        public Location CurrentLocation {  get; set; }
        public HealthCondition HealthCondition { get; set; }
        public AnimalType AnimalType { get; set; }

        public override string ToString()
        {
            return "BirthYear: " + BirthYear + "\nFoundLocation: " + FoundLocation + "\nCurrentLocation: " + CurrentLocation +
                "\nHealthCondition: " + HealthCondition + "\nAnimalType: " + AnimalType;
        }
    }
}

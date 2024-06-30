using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Animal : IEntity
    {
        public string Id {  get; set; }
        public int BirthYear { get; set; }
        public Location FoundLocation { get; set; }
        public Location CurrentLocation {  get; set; }
        public HealthCondition HealthCondition { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}

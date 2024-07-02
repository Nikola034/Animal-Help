using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class HealthCondition : IEntity
    {
        public HealthCondition() { }
        public HealthCondition(string description, HealthState healthState)
        {
            Id = "0";
            Description = description;
            HealthState = healthState;
        }
        public HealthCondition(string id, string description, HealthState healthState)
        {
            Id = id;
            Description = description;
            HealthState = healthState;
        }

        public string Id {  get; set; }
        public string Description { get; set; }
        public HealthState? HealthState { get; set; }

        public override string ToString()
        {
            return $"{HealthState}: {Description}";
        }
    }
}

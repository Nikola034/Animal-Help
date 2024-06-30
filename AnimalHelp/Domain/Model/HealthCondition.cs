using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class HealthCondition : IEntity
    {
        public string Id {  get; set; }
        public string Description { get; set; }
        public HealthState HealthState { get; set; }
    }
}

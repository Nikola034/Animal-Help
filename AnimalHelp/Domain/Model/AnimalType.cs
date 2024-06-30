using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class AnimalType : IEntity
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
    }
}

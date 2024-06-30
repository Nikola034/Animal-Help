using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Location : IEntity
    {
        public string Id {  get; set; }
        public string City {  get; set; }
        public string Street { get; set; }
        public string StreetNumber {  get; set; }
    }
}

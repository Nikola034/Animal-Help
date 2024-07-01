using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.Domain.Model
{
    public class Location : IEntity
    {
        public Location() { }
        public Location(string city, string street, string streetNumber)
        {
            Id = "0";
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }
        public Location(string id, string city, string street, string streetNumber)
        {
            Id = id;
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }

        public string Id {  get; set; }
        public string City {  get; set; }
        public string Street { get; set; }
        public string StreetNumber {  get; set; }

        public override string ToString()
        {
            return City + ", " + Street + ", " + StreetNumber;
        }
    }
}

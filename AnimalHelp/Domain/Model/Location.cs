namespace AnimalHelp.Domain.Model
{
    public class Location
    {
        public Location() { }
        public Location(string city, string street, string streetNumber)
        {
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }

        public override string ToString()
        {
            return City + ", " + Street + ", " + StreetNumber;
        }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }    }
}

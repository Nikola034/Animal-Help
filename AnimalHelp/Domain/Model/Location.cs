namespace AnimalHelp.Domain.Model
{
    public class Location
    {
        public Location(string city, string street, string streetNumber)
        {
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}

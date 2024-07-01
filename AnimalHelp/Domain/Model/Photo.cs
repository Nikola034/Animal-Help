namespace AnimalHelp.Domain.Model
{
    public class Photo : IEntity
    {
        public Photo() { }
        public Photo(string url, string description)
        {
            Id = "0";
            Url = url;
            Description = description;
        }

        public string Id {  get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "URL: " + Url + "\nDescription: " + Description;
        }
    }
}
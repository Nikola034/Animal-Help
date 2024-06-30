namespace AnimalHelp.Domain.Model
{
    public class Photo : IEntity
    {
        public string Id {  get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
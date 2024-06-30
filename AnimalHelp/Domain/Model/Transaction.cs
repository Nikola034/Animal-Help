namespace AnimalHelp.Domain.Model
{
    public class Transaction : IEntity
    {
        public string Id { get; set; }
        public float Amount {  get; set; }
        public string Receiver { get; set; }
        public bool IsAnonymous {  get; set; }
        public string Sender {  get; set; }
	public Post? Post { get; set; }
    }
}
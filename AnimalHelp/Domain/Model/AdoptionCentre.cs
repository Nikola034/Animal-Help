namespace AnimalHelp.Domain.Model
{
    public class AdoptionCentre(string id, string name, Location location, string bankAccount, string email, string instagramAccount) : IEntity
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Location Location { get; set; } = location;
        public string BankAccount { get; set; } = bankAccount;
        public string Email { get; set; } = email;
        public string InstagramAccount { get; set; } = instagramAccount;

        public AdoptionCentre()
            : this("", "", null, "", "", "")
        {
        }

        public AdoptionCentre(string name, Location location, string bankAccount, string email, string instagramAccount)
            : this("", name, location, bankAccount, email, instagramAccount) { }


    }
}

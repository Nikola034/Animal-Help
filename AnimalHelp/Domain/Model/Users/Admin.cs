using System;

namespace AnimalHelp.Domain.Model
{
    public class Admin : IEntity
    {
        public string Id { get; set; }
        public Profile Profile { get; set; }


        public Admin()
        {
            Id = "";
        }

        public Admin(string email, string password) 
        {
            Id = "";
            Profile = new Profile(email, password, UserType.Admin);
        }
        
        public Admin(string id, string email, string password)
        {
            Id = id;
            Profile = new Profile(email, password, UserType.Admin);
        }
    }
}

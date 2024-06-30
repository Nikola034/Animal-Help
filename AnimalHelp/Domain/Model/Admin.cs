using System;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Domain.Model
{
    public class Admin : Person, IEntity
    {
        public string Id { get; set; }
        
        public Admin() : base("", "", DateTime.Now, Gender.Other, "")
        {
            Id = "";
        }

        public Admin(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber) : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = "";
        }
        
        public Admin(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber) : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = id;
        }
    }
}

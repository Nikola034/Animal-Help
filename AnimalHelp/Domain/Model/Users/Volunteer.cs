using System;
using System.Collections.Generic;

namespace AnimalHelp.Domain.Model
{
    public class Volunteer : User, IEntity
    {
        public string Id { get; set; }

        public DateTime DateJoined { get; set; }

        public Volunteer() : base("", "", DateTime.Now, Gender.Other, "")
        {
            Id = "";
            DateJoined = DateTime.Now;
        }

        public Volunteer(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
            : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = "";
            DateJoined = DateTime.Now;
        }

        public Volunteer(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
            : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = id;
            DateJoined = DateTime.Now;
        }

        public void Update(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            BirthDate = birthDate;
            Gender = gender;
            PhoneNumber = phoneNumber;
            DateJoined = dateJoined;
        }
    }

}
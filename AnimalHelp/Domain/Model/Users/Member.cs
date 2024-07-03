using System;

namespace AnimalHelp.Domain.Model
{
    public class Member : User, IEntity
    {
        public Member() : base("", "", "", DateTime.Now, Gender.Other, "")
        {
        }

        public Member(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
            : base("", name, surname, birthDate, gender, phoneNumber)
        {
        }

        public Member(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
            : base(id, name, surname, birthDate, gender, phoneNumber)
        {
        }

        public void Update(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            BirthDate = birthDate;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}
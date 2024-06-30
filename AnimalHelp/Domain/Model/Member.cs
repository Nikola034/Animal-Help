using System;
using System.Collections.Generic;

namespace AnimalHelp.Domain.Model
{
    public class Member : Person, IEntity
    {
        public string Id { get; set; }

        public bool IsBlackListed { get; set; }
        public bool IsActive { get; set; }

        public Member() : base("", "", DateTime.Now, Gender.Other, "")
        {
            Id = "";
            IsBlackListed = false;
            IsActive = true;
        }

        public Member(string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, bool isBlackListed, bool isActive)
            : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = "";
            IsActive = isActive;
            IsBlackListed = isBlackListed;
        }

        public Member(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, bool isBlackListed, bool isActive)
            : base(name, surname, birthDate, gender, phoneNumber)
        {
            Id = id;
            IsActive = isActive;
            IsBlackListed = isBlackListed;
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

        public void BlackList()
        {
            IsBlackListed = true;
        }
    }

}
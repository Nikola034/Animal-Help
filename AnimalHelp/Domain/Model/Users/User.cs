using System;

namespace AnimalHelp.Domain.Model;

public abstract class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsBlackListed { get; set; }

    public Profile Profile { get; set; }

    protected User(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
    {
        Id = id;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        Gender = gender;
        PhoneNumber = phoneNumber;
        IsBlackListed = false;
    }

    protected User(string id, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, bool isBlackListed)
    {
        Id = id;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        Gender = gender;
        PhoneNumber = phoneNumber;
        IsBlackListed = isBlackListed;
    }


    public void AddProfile(string email, string password, UserType userType)
    {
        Profile = new Profile(email, password, userType);
    }

    public void ChangePassword(string newPassword)
    {
        Profile.Password = newPassword;
    }

    public void BlackList()
    {
        IsBlackListed = true;
    }
}

public enum Gender
{
    Female, Male, Other
}
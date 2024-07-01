using AnimalHelp.Domain.Model;
using System;
using System.Collections.Generic;

namespace AnimalHelp.Application.UseCases.User;

public interface IVolunteerService
{
    public List<Volunteer> GetAllVolunteers();

    public Volunteer AddVolunteer(Volunteer volunteer);

    public Volunteer? GetVolunteerById(string id);

    public void DeleteAccount(Volunteer volunteer);

    public bool UpdateVolunteer(Volunteer volunteer, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined, string email);

}
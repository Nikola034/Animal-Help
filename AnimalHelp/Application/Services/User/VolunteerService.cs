using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;


namespace AnimalHelp.Application.UseCases.User
{
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public List<Volunteer> GetAllVolunteers() => _volunteerRepository.GetAll();

        public Volunteer AddVolunteer(Volunteer volunteer) => _volunteerRepository.Add(volunteer);

        public Volunteer? GetVolunteerById(string id) => _volunteerRepository.Get(id);

        public void DeleteAccount(Volunteer volunteer) => _volunteerRepository.Delete(volunteer.Id);

        public bool UpdateVolunteer(Volunteer volunteer, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined, string email)
        {
            volunteer.Name = name;
            volunteer.Surname = surname;
            volunteer.Gender = gender;
            volunteer.BirthDate = birthDate;
            volunteer.Gender = gender;
            volunteer.PhoneNumber = phoneNumber;
            volunteer.DateJoined = dateJoined;
            volunteer.Profile.Email = email;

            _volunteerRepository.Update(volunteer.Id, volunteer);
            return true;
        }

    }
}
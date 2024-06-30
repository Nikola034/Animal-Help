using System;
using System.Collections.Generic;
using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.UseCases.User;
public interface IAccountService
{
    public void UpdateMember(string userId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber);
    public void RegisterMember(RegisterMemberDto registerDto);
    public Volunteer RegisterVolunteer(RegisterVolunteerDto registerDto);
    public Volunteer UpdateVolunteer(string volunteerId, string password, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber, DateTime dateJoined);
    public void DeleteMember(Member member);
    public string GetEmailByUserId(string userId, UserType userType);
    public bool IsEmailTaken(string email);
    public UserDto GetPerson(Profile profile);
    public UserDto GetPerson(string email);

}


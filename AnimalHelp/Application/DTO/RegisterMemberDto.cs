using System;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.DTO;

public class RegisterMemberDto : RegisterDto
{
    public EducationLevel EducationLevel { get; }

    public RegisterMemberDto(string email, string password, string name, string surname, DateTime birthDay, Gender gender, string phoneNumber, EducationLevel educationLvl)
    : base(email, password, name, surname, birthDay, gender, phoneNumber)
    {
        EducationLevel = educationLvl;
    }
}
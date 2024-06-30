using System;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.DTO;

public class RegisterVolunteerDto : RegisterDto
{
    public RegisterVolunteerDto(string email, string password, string name, string surname, DateTime birthDay, Gender gender, string phoneNumber)
    : base(email, password, name, surname, birthDay, gender, phoneNumber)
    {
    }
}
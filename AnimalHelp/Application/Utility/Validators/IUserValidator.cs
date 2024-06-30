using System;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.Utility.Validators;

public interface IUserValidator
{
    ValidationError CheckUserData(string? email, string? password, string? name, string? surname, string? phoneNumber, DateTime? birthDay);

    ValidationError EmailTaken(string email);
}
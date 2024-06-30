using System;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.UseCases.Authentication;

public interface IRegisterService
{
    public ValidationError RegisterMember(string? email, string? password, string? name, string? surname, DateTime birthDay,
        Gender gender, string? phoneNumber);

    public ValidationError RegisterVolunteer(string? email, string? password, string? name, string? surname, DateTime birthDay,
    Gender gender, string? phoneNumber);
}
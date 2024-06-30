using System;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Validators;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.UseCases.Authentication
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserValidator _userValidator;
        private readonly IAccountService _accountService;

        public RegisterService(IUserValidator userValidator, IAccountService accountService)
        {
            _userValidator = userValidator;
            _accountService = accountService;
        }

        public ValidationError RegisterMember(string? email, string? password, string? name, string? surname, DateTime birthDay, Gender gender, string? phoneNumber)
        {
            ValidationError error = ValidationError.None;
            error |= _userValidator.CheckUserData(email, password, name, surname, phoneNumber, birthDay);
            error |= _userValidator.EmailTaken(email!);

            if (error == ValidationError.None)
            {
                _accountService.RegisterMember(new RegisterMemberDto(
                    email!,
                    password!,
                    name!,
                    surname!,
                    birthDay,
                    gender,
                    phoneNumber!
                    ));
            }
            return error;
        }

        public ValidationError RegisterVolunteer(string? email, string? password, string? name, string? surname, DateTime birthDay, Gender gender, string? phoneNumber)
        {
            ValidationError error = ValidationError.None;
            error |= _userValidator.CheckUserData(email, password, name, surname, phoneNumber, birthDay);
            error |= _userValidator.EmailTaken(email!);

            if (error == ValidationError.None)
            {
                _accountService.RegisterVolunteer(new RegisterVolunteerDto(
                    email!,
                    password!,
                    name!,
                    surname!,
                    birthDay,
                    gender,
                    phoneNumber!
                    ));
            }
            return error;
        }


    }
}

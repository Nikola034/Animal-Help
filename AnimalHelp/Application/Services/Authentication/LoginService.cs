using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.UseCases.Authentication;

public class LoginService : ILoginService
{
    private readonly IAuthenticationStore _authenticationStore;

    private readonly IAccountService _accountService;

    public LoginService(IAuthenticationStore authenticationStore, IAccountService accountService)
    {
        _authenticationStore = authenticationStore;
        _accountService = accountService;
    }

    public LoginResult LogIn(string? email, string? password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            return new LoginResult(false);

        UserDto? user = _accountService.GetPerson(email);

        if (user.Person == null && user.Admin == null) return new LoginResult(false);

        Profile profile = null;
        if(user.UserType == UserType.Admin)
        {
            profile = user.Admin.Profile;
        }
        else
        {
            profile = user.Person.Profile;
        }



        if (profile.Password != password)
            return new LoginResult(false, true);

        if (!profile.IsActive)
            return new LoginResult(false, true);
        
        _authenticationStore.CurrentUserProfile = profile;
        _authenticationStore.UserType = profile.UserType;
        return new LoginResult(true, true, profile, _authenticationStore.UserType);
    }

    public void LogOut()
    {
        _authenticationStore.CurrentUserProfile = null;
        _authenticationStore.UserType = null;
    }
}
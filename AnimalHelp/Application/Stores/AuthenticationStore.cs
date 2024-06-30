using AnimalHelp.Application.DTO;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.Stores;

public class AuthenticationStore : IAuthenticationStore
{
    public Profile? CurrentUserProfile { get; set; }

    public bool IsLoggedIn => CurrentUserProfile != null;
    
    public UserType? UserType { get; set; }

    public UserDto CurrentUser => CurrentUserProfile != null ? _accountService.GetPerson(CurrentUserProfile) : new UserDto((Admin)null, null);

    private readonly IAccountService _accountService;

    public AuthenticationStore(IAccountService accountService)
    {
        this._accountService = accountService;
    }
}
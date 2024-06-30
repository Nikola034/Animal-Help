using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.DTO;

public class LoginResult
{
    public bool IsValidUser { get; }
    public Profile? Profile { get; }
    public UserType? UserType { get; }
    
    public bool IsValidEmail { get; }

    public LoginResult(bool isValidUser, bool isValidEmail = false, Profile? profile = null, UserType? userType = null)
    {
        IsValidUser = isValidUser;
        IsValidEmail = isValidEmail;
        Profile = profile;
        UserType = userType;
    }
}
namespace AnimalHelp.Domain.Model;

public class Profile
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public UserType UserType { get; set; }


    public Profile()
    {
        Email = "";
        Password = "";
    }
    
    public Profile(string email, string password)
    {
        Email = email;
        Password = password;
        IsActive = true;
    }

    public Profile(string email, string password, UserType userType)
    {
        Email = email;
        Password = password;
        UserType = userType;
        IsActive = true;
    }
    public Profile(string email, string password, UserType userType, bool isActive)
    {
        Email = email;
        UserType = userType;
        Password = password;
        IsActive = isActive;
    }

}

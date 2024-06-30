namespace AnimalHelp.Domain.Model;

public class PersonProfileMapping
{
    public string Email { get; set; }
    public string UserId { get; set; }
    public UserType UserType { get; set; }


    public PersonProfileMapping()
    {
        Email = "";
        UserType = UserType.Member;
        UserId = "";
    }

    public PersonProfileMapping(string email, UserType userType, string userId)
    {
        Email = email;
        UserType = userType;
        UserId = userId;
    }
}
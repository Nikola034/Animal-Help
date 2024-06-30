namespace AnimalHelp.Domain.Model;

public class PersonProfileMapping
{
    public string Email { get; set; }
    public string UserId { get; set; }

    public PersonProfileMapping()
    {
        Email = "";
        UserId = "";
    }

    public PersonProfileMapping(string email, string userId)
    {
        Email = email;
        UserId = userId;
    }
}
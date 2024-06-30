using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.DTO;

public class UserDto
{
    public User? Person { get; }
    public UserType? UserType { get; }
    public Admin? Admin { get; }

    public UserDto(User? person, UserType? userType)
    {
        Person = person;
        UserType = userType;
    }

    public UserDto(Admin? admin, UserType? userType)
    {
        Admin = admin;
        UserType = userType;
    }
}
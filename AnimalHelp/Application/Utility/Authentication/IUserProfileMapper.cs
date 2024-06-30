using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.Application.Utility.Authentication;

public interface IUserProfileMapper
{
    public UserDto GetPerson(Profile profile);
    public Profile? GetProfile(UserDto user);
}
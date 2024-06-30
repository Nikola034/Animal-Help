using AnimalHelp.Domain.Model;
using AnimalHelp.Application.DTO;

namespace AnimalHelp.Application.Stores;


public interface IAuthenticationStore
{
    public Profile? CurrentUserProfile { get; set; }
    public bool IsLoggedIn { get; }
    public UserType? UserType { get; set; }
    public UserDto CurrentUser { get; }
}
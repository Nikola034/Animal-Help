using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model;

namespace AnimalHelp.WPF.ViewModels.Volounteer.BlackList;

public class UserViewModel(UserDto userDto, float? rating)
{
    public string Name { get; } = userDto.Person!.Name;
    public string Surname { get; } = userDto.Person!.Surname;
    public UserType UserType { get; } = userDto.UserType!.Value;
    public float? Rating { get; } = rating;
    public User User { get; } = userDto.Person!;
}
using AnimalHelp.Application.DTO;

namespace AnimalHelp.Application.UseCases.Authentication;

public interface ILoginService
{
    public LoginResult LogIn(string email, string password);

    public void LogOut();
}
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Authentication;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Application.Utility.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddServicesHostBuilderExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IRegisterService, RegisterService>();
            services.AddSingleton<IProfileService, ProfileService>();
            services.AddSingleton<IUserProfileMapper, UserProfileMapper>();
            services.AddSingleton<IUserValidator, UserValidator>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<INavigationService, NavigationService>();


            services.AddSingleton<IMemberService, MemberService>();
            services.AddSingleton<IVolunteerService, VolunteerService>();

            services.AddSingleton<IPostService, PostService>();
        });

        return host;
    }
}
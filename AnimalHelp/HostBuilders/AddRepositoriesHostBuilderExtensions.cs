using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.Repositories;
using AnimalHelp.Repositories.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddRepositoriesHostBuilderExtensions
{
    public static IHostBuilder AddRepositories(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IProfileRepository, ProfileRepository>(_ =>
                new ProfileRepository(Constants.ProfileFilePath));
            services.AddSingleton<IPersonProfileMappingRepository, PersonProfileMappingRepository>(_ =>
                new PersonProfileMappingRepository(Constants.PersonProfileMappingFilePath));
            services.AddSingleton<IMemberRepository, MemberRepository>(_ =>
                new MemberRepository(Constants.MemberFilePath, Constants.UserIdFilePath));
            services.AddSingleton<IVolunteerRepository, VolunteerRepository>(_ =>
                new VolunteerRepository(Constants.VolunteerFilePath, Constants.UserIdFilePath));
            services.AddSingleton<IAdminRepository, AdminRepository>(_ =>
                new AdminRepository(Constants.AdminFilePath, Constants.AdminIdFilePath));



        });

        return host;
    }
}
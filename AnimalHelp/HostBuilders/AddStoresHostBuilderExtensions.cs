using AnimalHelp.Application.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddStoresHostBuilderExtensions
{
    public static IHostBuilder AddStores(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<IAuthenticationStore, AuthenticationStore>();
            services.AddSingleton<CurrentPostStore>();
            services.AddSingleton<CurrentAdoptionStore>();
            services.AddSingleton<CurrentBlackListProposalStore>();
        });
        
        return host;
    }
}
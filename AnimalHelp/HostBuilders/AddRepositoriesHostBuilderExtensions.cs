using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddRepositoriesHostBuilderExtensions
{
    public static IHostBuilder AddRepositories(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            
        });

        return host;
    }
}
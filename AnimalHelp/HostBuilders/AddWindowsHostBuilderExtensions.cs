using AnimalHelp.WPF.Views;
using AnimalHelp.WPF.Views.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddWindowsHostBuilderExtensions
{
    public static IHostBuilder AddWindows(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IAnimalHelpWindowFactory, AnimalHelpWindowFactory>();
            services.AddTransient<MainWindow>();
        });
        
        return host;
    }
}
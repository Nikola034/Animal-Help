using AnimalHelp.WPF.Util;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.Views.Common;
using AnimalHelp.WPF.Views.Donations;
using AnimalHelp.WPF.Views.Factories;
using AnimalHelp.WPF.Views.Member;
using AnimalHelp.WPF.Views.Volounteer;
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
            services.AddTransient<LoginWindow>();

            services.AddSingleton<IFileDialogService, FileDialogService>();
        });
        
        return host;
    }
}
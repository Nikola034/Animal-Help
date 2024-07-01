using System.Windows;
using AnimalHelp.HostBuilders;
using AnimalHelp.WPF.Views.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp
{
    public partial class App
    {
        private readonly IHost _host = CreateHostBuilder().Build();
        private static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, builder) => builder.AddUserSecrets<App>())
                .AddRepositories()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddWindows();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            Window window = _host.Services.GetRequiredService<LoginWindow>();
            window.Show();
            
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            base.OnExit(e);
        }
    }
}
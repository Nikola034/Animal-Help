using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.ViewModels.Factories;
using AnimalHelp.WPF.ViewModels.Member;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IAnimalHelpViewModelFactory, AnimalHelpViewModelFactory>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<CreatePostViewModel>();
            services.AddScoped<AdminMenuViewModel>();
            services.AddScoped<VolunteerRegistrationViewModel>();
            services.AddScoped<MemberMenuViewModel>();
            services.AddTransient<CreateDonationViewModel>();

            services.AddScoped<CreateViewModel<MainViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<MainViewModel>
            );

            services.AddScoped<CreateViewModel<LoginViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<LoginViewModel>
            );

            services.AddScoped<CreateViewModel<RegisterViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<RegisterViewModel>
            );

            services.AddScoped<CreateViewModel<CreatePostViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<CreatePostViewModel>
            );

            services.AddScoped<CreateViewModel<AdminMenuViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<AdminMenuViewModel>
            );

            services.AddScoped<CreateViewModel<VolunteerRegistrationViewModel>>(
                servicesProvider => servicesProvider.GetRequiredService<VolunteerRegistrationViewModel>
            );

            services.AddScoped<CreateViewModel<MemberMenuViewModel>>(
                servicesProvider => servicesProvider.GetRequiredService<MemberMenuViewModel>
            );
            
            services.AddScoped<CreateViewModel<CreateDonationViewModel>>(
                serviceProvider => serviceProvider.GetRequiredService<CreateDonationViewModel>
            );
        });

        return host;
    }
}
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.Views.Admin;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.Views.Common;
using AnimalHelp.WPF.Views.Member;
using System;
using System.Windows;

namespace AnimalHelp.WPF.Views.Factories;

public class AnimalHelpWindowFactory : IAnimalHelpWindowFactory
{
    public Window CreateWindow(ViewModelBase viewModel)
    {
        return viewModel switch
        {
            LoginViewModel loginViewModel => new LoginWindow(loginViewModel, this),
            RegisterViewModel registerViewModel => new RegisterWindow(registerViewModel, this),
            AdminMenuViewModel adminMenuViewModel => new AdminMenuWindow(adminMenuViewModel, this),
            MemberMenuViewModel memberMenuViewModel => new MemberMenuWindow(memberMenuViewModel, this),
            CreateDonationViewModel createDonationViewModel => new Donations.CreateDonationWindow(createDonationViewModel, this),
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel), viewModel,
                "No Window exists for the given ViewModel: " + viewModel.GetType())
        };
    }
}
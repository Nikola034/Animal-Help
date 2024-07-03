using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Admin;
using AnimalHelp.WPF.ViewModels.Common;
using AnimalHelp.WPF.ViewModels.Member;
using AnimalHelp.WPF.ViewModels.Volounteer;
using AnimalHelp.WPF.Views.Admin;
using AnimalHelp.WPF.ViewModels.Donations;
using AnimalHelp.WPF.Views.Common;
using AnimalHelp.WPF.Views.Member;
using AnimalHelp.WPF.Views.Volounteer;
using System;
using System.Windows;
using AnimalHelp.WPF.ViewModels.Default;
using AnimalHelp.WPF.ViewModels.Volounteer.BlackList;
using AnimalHelp.WPF.Views.Default;
using AnimalHelp.WPF.Views.Volounteer.BlackList;

namespace AnimalHelp.WPF.Views.Factories;

public class AnimalHelpWindowFactory : IAnimalHelpWindowFactory
{
    public Window CreateWindow(ViewModelBase viewModel)
    {
        return viewModel switch
        {
            MainViewModel mainViewModel => new MainWindow(mainViewModel, this),
            LoginViewModel loginViewModel => new LoginWindow(loginViewModel, this),
            RegisterViewModel registerViewModel => new RegisterWindow(registerViewModel, this),
            AdminMenuViewModel adminMenuViewModel => new AdminMenuWindow(adminMenuViewModel, this),
            MemberMenuViewModel memberMenuViewModel => new MemberMenuWindow(memberMenuViewModel, this),
            VolounteerMenuViewModel volounteerMenuViewModel => new VolounteerMenuWindow(volounteerMenuViewModel, this),
            CreateDonationViewModel createDonationViewModel => new Donations.CreateDonationWindow(createDonationViewModel, this),
            AdoptionRequestViewModel adoptionRequestViewModel => new AdoptionRequestWindow(adoptionRequestViewModel, this),
            RateAnimalViewModel rateAnimalViewModel => new RateAnimalWindow(rateAnimalViewModel, this),
            BlackListDiscussionViewModel blackListDiscussionViewModel => new BlackListDiscussionWindow(blackListDiscussionViewModel, this),
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel), viewModel,
                "No Window exists for the given ViewModel: " + viewModel.GetType())
        };
    }
}
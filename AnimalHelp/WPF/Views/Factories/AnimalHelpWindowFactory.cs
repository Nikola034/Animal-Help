using System;
using System.Windows;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels;

namespace AnimalHelp.WPF.Views.Factories;

public class AnimalHelpWindowFactory : IAnimalHelpWindowFactory
{
    public Window CreateWindow(ViewModelBase viewModel)
    {
        return viewModel switch
        {
            MainViewModel mainViewModel => new MainWindow(mainViewModel, this),
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel), viewModel,
                "No Window exists for the given ViewModel: " + viewModel.GetType())
        };
    }
}
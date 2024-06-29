using System;
using System.Windows.Input;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.ViewModels;

public class MainViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }
    
    public string Text { get; set; }
    public ICommand Command;

    public MainViewModel(NavigationStore navigationStore)
    {
        Text = "Hello";
        Command = new RelayCommand(_ => Test());
        NavigationStore = navigationStore;
    }

    private void Test()
    {
        Console.WriteLine("test");
    }
}
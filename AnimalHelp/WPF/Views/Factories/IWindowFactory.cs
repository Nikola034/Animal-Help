using System.Windows;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.Views.Factories;

public interface IWindowFactory
{
    public Window CreateWindow(ViewModelBase viewModel);
}
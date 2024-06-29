using AnimalHelp.Application.Stores;

namespace AnimalHelp.WPF.MVVM;

public interface INavigableDataContext
{
    public NavigationStore NavigationStore { get; }
}
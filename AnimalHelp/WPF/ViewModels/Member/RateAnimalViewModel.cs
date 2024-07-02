using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Member;

public class RateAnimalViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }

    public ICommand SubmitRatingCommand { get; }

    public RateAnimalViewModel(NavigationStore navigationStore)
    {
        NavigationStore = navigationStore;
        SubmitRatingCommand = new RelayCommand<string>(SubmitRating);
    }

    private void SubmitRating(string rating)
    {
        throw new NotImplementedException();
    }
}

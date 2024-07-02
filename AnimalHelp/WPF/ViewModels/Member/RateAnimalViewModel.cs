using AnimalHelp.Application.Services.AdoptionServices;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Member;

public class RateAnimalViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }

    public ICommand SubmitRatingCommand { get; }
    private readonly IAdoptionService _adoptionService;
    private readonly CurrentAdoptionStore _currentAdoptionStore;

    public RateAnimalViewModel(NavigationStore navigationStore, IAdoptionService adoptionService, CurrentAdoptionStore currentAdoptionStore)
    {
        NavigationStore = navigationStore;
        _adoptionService = adoptionService;
        _currentAdoptionStore = currentAdoptionStore;
        SubmitRatingCommand = new RelayCommand(SubmitRating);
    }

    private void SubmitRating(object rating)
    {
        int selectedRating = Convert.ToInt32(rating);

        _adoptionService.RateAnimal(_currentAdoptionStore.CurrentAdoption.Id, selectedRating);
        MessageBox.Show("Rating submitted successfully");
        NavigationStore.ClosePopup();
    }
}

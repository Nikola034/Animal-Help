using AnimalHelp.Application.Services.AdoptionCentre;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.Views.Volounteer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class CreateAnimalViewModel : ViewModelBase, INavigableDataContext 
    {
        private readonly IAnimalService _animalService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;

        private ObservableCollection<Animal> _animals;
        public ObservableCollection<Animal> Animals
        {
            get => _animals;
            set
            {
                _animals = value;
                OnPropertyChanged(nameof(Animals));
            }
        }

        public RelayCommand AddAnimalCommand { get; }
        public NavigationStore NavigationStore { get; }
        public CreateAnimalViewModel(IAuthenticationStore authenticationStore, IAnimalService animalService, IMemberService memberService, IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _animalService = animalService;
            _authenticationStore = authenticationStore;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            Animals = new();

            AddAnimalCommand = new RelayCommand(AddAnimal!);

            LoadAnimals();
        }

        private void LoadAnimals()
        {
            Animals.Clear();
            List<Domain.Model.Animal> animals;

            animals = _animalService.GetAll();
            foreach (Domain.Model.Animal animal in animals)
                Animals.Add(animal);
        }

        private void AddAnimal(object parameter)
        {

        }
    }
}

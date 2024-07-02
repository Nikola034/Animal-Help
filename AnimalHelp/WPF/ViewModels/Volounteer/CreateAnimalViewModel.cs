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
using System.Windows.Controls;

namespace AnimalHelp.WPF.ViewModels.Volounteer
{
    public class CreateAnimalViewModel : ViewModelBase, INavigableDataContext 
    {
        private readonly IAnimalService _animalService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationStore _authenticationStore;

        private ObservableCollection<HealthState> _healthStates;
        public ObservableCollection<HealthState> HealthStates
        {
            get => _healthStates;
            set
            {
                _healthStates = value;
                OnPropertyChanged(nameof(HealthState));
            }
        }

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
        public RelayCommand UpdateAnimalCommand { get; }
        public RelayCommand DeleteAnimalCommand { get; }

        public NavigationStore NavigationStore { get; }
        public CreateAnimalViewModel(IAuthenticationStore authenticationStore, IAnimalService animalService, IMemberService memberService, IPostService postService, INavigationService navigationService, NavigationStore navigationStore)
        {
            _animalService = animalService;
            _authenticationStore = authenticationStore;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            Animals = new();
            HealthStates = new();

            AddAnimalCommand = new RelayCommand(AddAnimal!);
            UpdateAnimalCommand = new RelayCommand(UpdateAnimal!);
            DeleteAnimalCommand = new RelayCommand(DeleteAnimal!);

            LoadAnimals();
            LoadHealthStates();
        }

        private void LoadHealthStates()
        {
            foreach (HealthState healthState in Enum.GetValues(typeof(HealthState)))
                HealthStates.Add(healthState);
        }
        public bool selectingAnimal;
        private Animal? _selectedItem;
        public Animal? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                selectingAnimal = true;
                if (_selectedItem != null)
                {
                    Domain.Model.Animal? animal = _animalService.GetById(_selectedItem.Id);
                    if (animal == null)
                        return;
                    BirthYear = animal.BirthYear.ToString();
                    FoundLocationCity = animal.FoundLocation.City;
                    FoundLocationStreet = animal.FoundLocation.Street;
                    FoundLocationStreetNumber = animal.FoundLocation.StreetNumber;
                    CurrentLocationCity = animal.CurrentLocation.City;
                    CurrentLocationStreetNumber = animal.CurrentLocation.StreetNumber;
                    CurrentLocationStreet = animal.CurrentLocation.Street;
                    HealthConditionDescription = animal.HealthCondition.Description;
                    HealthConditionHealthState = (HealthState)animal.HealthCondition.HealthState;
                    AnimalTypeName = animal.AnimalType.Name;
                    AnimalTypeBreed = animal.AnimalType.Breed;
                    Name = animal.Name;
                    Description = animal.Description;
                }
                selectingAnimal = false;
                OnPropertyChanged();
            }
        }
        private string? _birthYear;
        public string? BirthYear
        {
            get => _birthYear;
            set => SetField(ref _birthYear, value);
        }
        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }
        private string? _description;
        public string? Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        private string? _foundLocationCity;
        public string? FoundLocationCity
        {
            get => _foundLocationCity;
            set => SetField(ref _foundLocationCity, value);
        }

        private string? _foundLocationStreet;
        public string? FoundLocationStreet
        {
            get => _foundLocationStreet;
            set => SetField(ref _foundLocationStreet, value);
        }

        private string? _foundLocationStreetNumber;
        public string? FoundLocationStreetNumber
        {
            get => _foundLocationStreetNumber;
            set => SetField(ref _foundLocationStreetNumber, value);
        }

        private string? _currentLocationCity;
        public string? CurrentLocationCity
        {
            get => _currentLocationCity;
            set => SetField(ref _currentLocationCity, value);
        }

        private string? _currentLocationStreet;
        public string? CurrentLocationStreet
        {
            get => _currentLocationStreet;
            set => SetField(ref _currentLocationStreet, value);
        }

        private string? _currentLocationStreetNumber;
        public string? CurrentLocationStreetNumber
        {
            get => _currentLocationStreetNumber;
            set => SetField(ref _currentLocationStreetNumber, value);
        }

        private string? _healthConditionDescription;
        public string? HealthConditionDescription
        {
            get => _healthConditionDescription;
            set => SetField(ref _healthConditionDescription, value);
        }

        private HealthState _healthConditionHealthState;
        public HealthState HealthConditionHealthState
        {
            get => _healthConditionHealthState;
            set => SetField(ref _healthConditionHealthState, value);
        }

        private string? _animalTypeName;
        public string? AnimalTypeName
        {
            get => _animalTypeName;
            set => SetField(ref _animalTypeName, value);
        }

        private string? _animalTypeBreed;
        public string? AnimalTypeBreed
        {
            get => _animalTypeBreed;
            set => SetField(ref _animalTypeBreed, value);
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
            if (BirthYear == null || !int.TryParse(BirthYear, out int x) || Name == null || Description == null || FoundLocationCity == null || FoundLocationStreet == null || FoundLocationStreetNumber == null ||
                CurrentLocationCity == null || CurrentLocationStreet == null || CurrentLocationStreetNumber == null ||
                HealthConditionDescription == null || AnimalTypeName == null ||
                AnimalTypeBreed == null)
            {
                return;
            }

            Animal newAnimal = new Animal(int.Parse(BirthYear), Name, Description, new Location(FoundLocationCity, FoundLocationStreet, FoundLocationStreetNumber),
                new Location(CurrentLocationCity, CurrentLocationStreet, CurrentLocationStreetNumber),
                new HealthCondition(HealthConditionDescription, HealthConditionHealthState), new AnimalType(AnimalTypeName, AnimalTypeBreed));

            Animals.Add(newAnimal);
            _animalService.Add(newAnimal);

            RemoveInputs();
        }

        private void UpdateAnimal(object parameter)
        {
            if (SelectedItem == null)
                return;

            Domain.Model.Animal animal = _animalService.Update(SelectedItem.Id,
                new Animal(SelectedItem.Id, int.Parse(BirthYear), Name, Description, new Location(FoundLocationCity, FoundLocationStreet, FoundLocationStreetNumber),
                new Location(CurrentLocationCity, CurrentLocationStreet, CurrentLocationStreetNumber),
                new HealthCondition(HealthConditionDescription, HealthConditionHealthState), new AnimalType(AnimalTypeName, AnimalTypeBreed)));

            Animals.Remove(SelectedItem);
            Animals.Add(animal);
           
            RemoveInputs();
        }

        private void DeleteAnimal(object parameter)
        {
            if (SelectedItem == null)
                return;
            Domain.Model.Animal? animal = _animalService.GetById(SelectedItem.Id);
            if (animal == null)
                return;
            _animalService.Delete(animal.Id);
            Animals.Remove(SelectedItem);
            RemoveInputs();
        }

        private void RemoveInputs()
        {
            BirthYear = "";
            FoundLocationCity = "";
            FoundLocationStreet = "";
            FoundLocationStreetNumber = "";
            CurrentLocationCity = "";
            CurrentLocationStreetNumber = "";
            CurrentLocationStreet = "";
            HealthConditionDescription = "";            
            AnimalTypeName = "";
            AnimalTypeBreed = "";
            Name = "";
            Description = "";
        }
    }
}

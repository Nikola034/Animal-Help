using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.UseCases.User;
using AnimalHelp.Application.Utility.Validators;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace AnimalHelp.WPF.ViewModels.Admin
{
    public class VolunteerRegistrationViewModel : ViewModelBase, INavigableDataContext
    {
        private readonly IVolunteerService _volunteerService;
        private readonly IAccountService _accountService;
        private readonly IUserValidator _userValidator;
        private readonly IRegisterService _registerService;

        public NavigationStore NavigationStore { get; }

        public RelayCommand AddKnownLangaugeCommand { get; }
        public RelayCommand ChangeLanguageCommand { get; }
        public RelayCommand ChangeLevelCommand { get; }
        public RelayCommand DeleteKnownLanguageCommand { get; }
        public RelayCommand RefreshSelectionCommand { get; }
        public RelayCommand AddVolunteerCommand { get; }
        public RelayCommand DeleteVolunteerCommand { get; }
        public RelayCommand UpdateVolunteerCommand { get; }
        public RelayCommand ClearFiltersCommand { get; }
        public RelayCommand PreviousPageCommand { get; }
        public RelayCommand NextPageCommand { get; }

        public ObservableCollection<Volunteer> Volunteers { get; set; }
        public ObservableCollection<Gender> Genders { get; set; }

        public bool selectingVolunteer;


        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }
        private string _surname = "";
        public string Surname
        {
            get => _surname;
            set => SetField(ref _surname, value);
        }
        private string _email = "";
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetField(ref _phoneNumber, value);
        }
        private Gender _selectedGender;
        public Gender SelectedGender
        {
            get => _selectedGender;
            set => SetField(ref _selectedGender, value);
        }

        private DateTime? _birthDate = null;
        public DateTime? BirthDate
        {
            get => _birthDate;
            set => SetField(ref _birthDate, value);
        }
        private DateTime? _dateJoined = null;
        public DateTime? DateJoined
        {
            get => _dateJoined != null ? _dateJoined : DateTime.Now;
            set => SetField(ref _dateJoined, value);
        }




        private Volunteer? _selectedItem;
        public Volunteer? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                selectingVolunteer = true;
                if (_selectedItem != null)
                {
                    Domain.Model.Volunteer? volunteer = _volunteerService.GetVolunteerById(_selectedItem.Id);
                    if (volunteer == null)
                        return;
                    Name = volunteer.Name;
                    Surname = volunteer.Surname;
                    Email = volunteer.Profile.Email;
                    Password = volunteer.Profile.Password;
                    PhoneNumber = volunteer.PhoneNumber;
                    BirthDate = volunteer.BirthDate;
                    DateJoined = volunteer.DateJoined;
                    SelectedGender = volunteer.Gender;
                }
                selectingVolunteer = false;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<int> PageSizeOptions { get; }

        public VolunteerRegistrationViewModel(NavigationStore navigationStore, IAccountService accountService, IVolunteerService volunteerService, IUserValidator userValidator)
        {
            NavigationStore = navigationStore;
            _accountService = accountService;
            _volunteerService = volunteerService;
            _userValidator = userValidator;
            Volunteers = new();
            Genders = new();
            LoadCollections();



            PageSizeOptions = new ObservableCollection<int>() { 1, 5, 10, 20 };

            AddVolunteerCommand = new RelayCommand(execute => AddVolunteer());
            DeleteVolunteerCommand = new RelayCommand(execute => DeleteVolunteer());
            UpdateVolunteerCommand = new RelayCommand(execute => UpdateVolunteer());

            RefreshSelectionCommand = new RelayCommand(execute => RefreshSelection());

        }
        private void LoadCollections()
        {
            LoadVolunteers();
            LoadGenders();
        }




        private void RefreshSelection() => SelectedItem = _selectedItem;


        private void UpdateVolunteer()
        {
            if (SelectedItem == null)
                return;

            bool errored = ErrorInvalidVolunteer(true);
            if (errored)
                return;



            Domain.Model.Volunteer volunteer = _accountService.UpdateVolunteer(SelectedItem.Id, Password, Name, Surname, (DateTime)BirthDate!, SelectedGender, PhoneNumber, (DateTime)DateJoined);
            Volunteers.Remove(SelectedItem);
            Volunteers.Add(volunteer);
            RemoveInputs();
        }
        private void DeleteVolunteer()
        {
            if (SelectedItem == null)
                return;
            Domain.Model.Volunteer? volunteer = _volunteerService.GetVolunteerById(SelectedItem.Id);
            if (volunteer == null)
                return;
            //mozda uraditi samo blacklisting ovde
            //_accountService.(tutor);
            Volunteers.Remove(SelectedItem);
            RemoveInputs();
        }

        private void AddVolunteer()
        {
            bool errored = ErrorInvalidVolunteer(false);
            if (errored)
                return;



            Domain.Model.Volunteer volunteer = _accountService.RegisterVolunteer(new Application.DTO.RegisterVolunteerDto(
                Email,
                Password,
                Name,
                Surname,
                (DateTime)BirthDate!,
                SelectedGender,
                PhoneNumber));
            Volunteers.Add(volunteer);
            RemoveInputs();
            MessageBox.Show("The tutor was added successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private bool ErrorInvalidVolunteer(bool updating)
        {
            ValidationError error = ValidationError.None;
            error |= _userValidator.CheckUserData(Email, Password, Name, Surname, PhoneNumber, BirthDate);
            if (!updating)
                error |= _userValidator.EmailTaken(Email);


            if (error == ValidationError.None)
                return false;

            List<string> messages = error.GetAllMessages();
            string combinedMessage = string.Join(",\n", messages);
            MessageBox.Show(combinedMessage, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            return true;
        }
        private void LoadVolunteers()
        {
            Volunteers.Clear();
            List<Domain.Model.Volunteer> volunteers;

            volunteers = _volunteerService.GetAllVolunteers();
            foreach (Domain.Model.Volunteer volunteer in volunteers)
                Volunteers.Add(volunteer);
        }

        private void LoadGenders()
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
                Genders.Add(gender);
        }
        private void RemoveInputs()
        {
            Name = "";
            Surname = "";
            Email = "";
            Password = "";
            PhoneNumber = "";
            BirthDate = null;
            DateJoined = null;
            _selectedItem = null;

            selectingVolunteer = true;
        }

    }
}

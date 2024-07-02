using AnimalHelp.Application.Services.AdoptionCentre;
using AnimalHelp.Application.Stores;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.ViewModels.Admin
{
    public class AgencyInformationViewModel : ViewModelBase, INavigableDataContext
    {
        private readonly IAdoptionCentreService _adoptionCentreService;
        public NavigationStore NavigationStore { get; }
        public RelayCommand UpdateAdoptionCentreCommand { get; }

        private AdoptionCentre _adoptionCentre;

        public string Name { get; set; }
        public string Email { get; set; }
        public string InstagramAccount { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string BankAccount { get; set; }

        public AgencyInformationViewModel(NavigationStore navigationStore, IAdoptionCentreService adoptionCentreService)
        {
            _adoptionCentreService = adoptionCentreService;
            NavigationStore = navigationStore;
            _adoptionCentre = adoptionCentreService.Get();
            setFields();
            UpdateAdoptionCentreCommand = new RelayCommand(execute => updateAdoptionCentre());
        }

        private void setFields()
        {
            Name = _adoptionCentre.Name;
            Email = _adoptionCentre.Email;
            InstagramAccount = _adoptionCentre.InstagramAccount;
            BankAccount = _adoptionCentre.BankAccount;
            if (_adoptionCentre.Location != null)
            {
                City = _adoptionCentre.Location.City;
                Street = _adoptionCentre.Location.Street;
                StreetNumber = _adoptionCentre.Location.StreetNumber;
            }
            else
            {
                City = "";
                Street = "";
                StreetNumber = "";
            }
        }

        private void updateAdoptionCentre()
        {
            _adoptionCentre.Name = Name;
            _adoptionCentre.Email = Email;
            _adoptionCentre.InstagramAccount = InstagramAccount;
            _adoptionCentre.Location = new Location(City, Street, StreetNumber);
            _adoptionCentre.BankAccount = BankAccount;
            _adoptionCentreService.Update(_adoptionCentre);
        }
    }
}

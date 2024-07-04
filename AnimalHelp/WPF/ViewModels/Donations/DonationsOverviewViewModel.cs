using System.Windows.Input;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class DonationsOverviewViewModel : ViewModelBase
{
    public DonationsListViewModel DonationsListViewModel { get; }
    
    public ICommand AddDonationCommand { get; }
    
    public ICommand ImportTransactionsCommand { get; }

    private readonly IPopupNavigationService _popupNavigationService;

    public DonationsOverviewViewModel(IAnimalHelpViewModelFactory viewModelFactory, IPopupNavigationService popupNavigationService)
    {
        _popupNavigationService = popupNavigationService;
        DonationsListViewModel = (DonationsListViewModel)viewModelFactory.CreateViewModel(ViewType.DonationList);
        AddDonationCommand = new RelayCommand(_ => OpenNewDonationWindow());
        ImportTransactionsCommand = new RelayCommand(_ => OpenTransactionImportWindow());
    }

    private void OpenNewDonationWindow()
    {
        _popupNavigationService.Navigate(ViewType.CreateDonation);
    }

    private void OpenTransactionImportWindow()
    {
        _popupNavigationService.Navigate(ViewType.TransactionImport);
    }
}
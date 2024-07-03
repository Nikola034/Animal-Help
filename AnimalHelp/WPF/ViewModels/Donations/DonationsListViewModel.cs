using System.Collections.ObjectModel;
using System.Linq;
using AnimalHelp.Application.Services.DonationServices;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class DonationsListViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }

    public ObservableCollection<IDateTimeSortable> Donations { get; }

    public DonationsListViewModel(NavigationStore navigationStore, IDonationService donationService, ITransactionService transactionService)
    {
        NavigationStore = navigationStore;

        var donations = donationService.GetAll()
            .Select(dto => new DonationViewModel(dto)).ToList();
        var transactions = transactionService.GetAll()
            .Select(dto => new TransactionViewModel(dto)).ToList();

        Donations = new ObservableCollection<IDateTimeSortable>(
            donations.Cast<IDateTimeSortable>()
                .Concat(transactions)
                .OrderBy(item => item.DateTime)
                .ToList()
        );
    }
}
using System.Collections.ObjectModel;
using System.Linq;
using AnimalHelp.Application.Services.DonationServices;
using AnimalHelp.Application.Stores;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class DonationsListViewModel : ViewModelBase
{
    private readonly IDonationService _donationService;
    private readonly ITransactionService _transactionService;
    private readonly DonationStore _donationStore;

    private ObservableCollection<IDateTimeSortable> _donations;

    public ObservableCollection<IDateTimeSortable> Donations
    {
        get => _donations;
        private set => SetField(ref _donations, value);
    }

    public DonationsListViewModel(IDonationService donationService, ITransactionService transactionService, DonationStore donationStore)
    {
        _donationService = donationService;
        _transactionService = transactionService;
        _donationStore = donationStore;
        var donations = donationService.GetAll()
            .Select(dto => new DonationViewModel(dto)).ToList();
        var transactions = transactionService.GetAll()
            .Select(dto => new TransactionViewModel(dto)).ToList();

        _donations = new ObservableCollection<IDateTimeSortable>(
            donations.Cast<IDateTimeSortable>()
                .Concat(transactions)
                .OrderBy(item => item.DateTime)
                .ToList()
        );

        _donationStore.DonationListUpdated += ReloadDonations;
    }

    public void ReloadDonations()
    {
        var donations = _donationService.GetAll()
            .Select(dto => new DonationViewModel(dto)).ToList();
        var transactions = _transactionService.GetAll()
            .Select(dto => new TransactionViewModel(dto)).ToList();

        Donations = new ObservableCollection<IDateTimeSortable>(
            donations.Cast<IDateTimeSortable>()
                .Concat(transactions)
                .OrderBy(item => item.DateTime)
                .ToList()
        );
    }
}
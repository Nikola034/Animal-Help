using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using AnimalHelp.Application.Services.DonationServices;
using AnimalHelp.Application.Services.Post;
using AnimalHelp.Application.Stores;
using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.Model.Donations;
using AnimalHelp.WPF.MVVM;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class ImportTransactionsViewModel : ViewModelBase, INavigableDataContext
{
    public NavigationStore NavigationStore { get; }
    
    private readonly ITransactionService _transactionService;
    private readonly IFileDialogService _fileDialogService;

    private ObservableCollection<Transaction> _transactions;
    private Transaction? _selectedTransaction;
    private ObservableCollection<Post> _posts;
    
    public ICommand SelectFileCommand { get; }
    public ICommand SaveCommand { get; }
    
    public ImportTransactionsViewModel(NavigationStore navigationStore, ITransactionService transactionService, IFileDialogService fileDialogService, IPostService postService)
    {
        NavigationStore = navigationStore;
        _transactionService = transactionService;
        _fileDialogService = fileDialogService;
        _transactions = new();
        _posts = new ObservableCollection<Post>(postService.GetAll());
        SelectFileCommand = new RelayCommand(_ => ImportFile());
        SaveCommand = new RelayCommand(_ => Save(), _ => CanSave());
    }
    
    public ObservableCollection<Transaction> Transactions
    {
        get => _transactions;
        private set => SetField(ref _transactions, value);
    }
    
    public Transaction? SelectedTransaction
    {
        get => _selectedTransaction;
        set => SetField(ref _selectedTransaction, value);
    }
    
    public ObservableCollection<Post> Posts
    {
        get => _posts;
        set => SetField(ref _posts, value);
    }

    private void ImportFile()
    {
        var filepath = _fileDialogService.OpenFileDialog(
            "Select Bank Statement XML file",
            new[] { "xml" }
        );
        if (filepath == null)
            return;
        var transactions = _transactionService.UploadBankStatement(filepath);
        Transactions = new ObservableCollection<Transaction>(transactions);
    }
    
    private void Save()
    {
        _transactionService.SaveTransactions(Transactions.ToList());
        Transactions.Clear();
        MessageBox.Show("Transactions saved successfully.", "Success");
    }

    private bool CanSave()
    {
        return Transactions.Count > 0;
    }
}
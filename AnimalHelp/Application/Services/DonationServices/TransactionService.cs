using System.Collections.Generic;
using System.Linq;
using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Services.AdoptionCentre;
using AnimalHelp.Domain.Model.Donations;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Application.Services.DonationServices;

public class TransactionService(
    ITransactionRepository transactionRepository,
    IAdoptionCentreService adoptionCentreService,
    ITransactionParser transactionParser
    ) : ITransactionService
{
    public List<TransactionDto> GetAll()
        => transactionRepository.GetAll().Select(ConvertToDto).OfType<TransactionDto>().ToList();

    private TransactionDto? ConvertToDto(Transaction transaction)
    {
        var ownAccountNum = adoptionCentreService.Get().BankAccount;
        
        if (transaction.Sender.AccountNumber == ownAccountNum)
        {
            return TransactionDto.FromTransaction(transaction, true);
        }

        if (transaction.Receiver.AccountNumber == ownAccountNum)
        {
            return TransactionDto.FromTransaction(transaction, false);
        }

        return null;
    }

    public List<Transaction> UploadBankStatement(string filepath)
    {
        return transactionParser.ParseFile(filepath);
    }

    public void SaveTransactions(IEnumerable<Transaction> transactions)
    {
        transactionRepository.AddUnique(transactions);
    }
}

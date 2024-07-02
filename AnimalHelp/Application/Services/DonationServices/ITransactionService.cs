using System.Collections.Generic;
using AnimalHelp.Application.DTO;
using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.Application.Services.DonationServices;

public interface ITransactionService
{
    public List<TransactionDto> GetAll();
    public List<Transaction> UploadBankStatement(string filepath);
    public void SaveTransactions(IEnumerable<Transaction> transactions);
}
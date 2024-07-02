using System.Collections.Generic;
using System.Linq;
using AnimalHelp.Domain.Model.Donations;
using AnimalHelp.Domain.RepositoryInterfaces;

namespace AnimalHelp.Repositories.Json;

public class TransactionRepository(string filepath)
    : Repository<Transaction>(filepath), ITransactionRepository
{
    protected override string GetId(Transaction item)
    {
        return item.Id;
    }

    public List<Transaction> AddUnique(IEnumerable<Transaction> transactions)
    {
        var oldTransactions = GetAll();
        var addedTransactions = new List<Transaction>();
        foreach (var transaction in transactions.Distinct())
        {
            if (oldTransactions.Contains(transaction))
                continue;
            addedTransactions.Add(Add(transaction));
        }

        return addedTransactions;
    }
}
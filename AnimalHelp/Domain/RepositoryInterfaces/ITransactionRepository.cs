using System.Collections.Generic;
using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface ITransactionRepository : IRepository<Transaction>
{
    public List<Transaction> AddUnique(IEnumerable<Transaction> transactions);
}
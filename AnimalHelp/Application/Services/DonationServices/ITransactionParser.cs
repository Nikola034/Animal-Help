using System.Collections.Generic;
using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.Application.Services.DonationServices;

public interface ITransactionParser
{
    public List<Transaction> ParseFile(string filepath);
}
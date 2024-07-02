using System;
using System.Collections.Generic;
using System.Globalization;
using AnimalHelp.Application.Services.DonationServices;
using AnimalHelp.Domain.Model.Donations;
using System.Xml.Linq;

namespace AnimalHelp.Application.Utility.XmlServices;

public class XmlTransactionParser : ITransactionParser
{
    public List<Transaction> ParseFile(string filepath)
    {
        var transactions = new List<Transaction>();

        var doc = XDocument.Load(filepath);
        var transactionElements = doc.Descendants("transaction");

        foreach (var element in transactionElements)
        {
            var transaction = new Transaction
            {
                Id = (string)element.Element("id"),
                DateTime = DateTime.Parse((string)element.Element("datetime"), null, DateTimeStyles.AdjustToUniversal),
                Amount = float.Parse((string)element.Element("amount"), CultureInfo.InvariantCulture),
                Sender = new BankAccount
                {
                    AccountNumber = (string)element.Element("sender")!.Element("account-number"),
                    Owner = (string)element.Element("sender")!.Element("name")
                },
                Receiver = new BankAccount
                {
                    AccountNumber = (string)element.Element("receiver")!.Element("account-number"),
                    Owner = (string)element.Element("receiver")!.Element("name")
                },
                IsAnonymous = false,
                Post = null
            };

            transactions.Add(transaction);
        }

        return transactions;
    }
}
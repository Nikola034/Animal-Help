using System;
using AnimalHelp.Application.DTO;

namespace AnimalHelp.WPF.ViewModels.Donations;

public class TransactionViewModel(TransactionDto transaction) : IDateTimeSortable
{
    public DateTime DateTime { get; } = transaction.DateTime;
    public float Amount { get; } = transaction.IsPayment ? -transaction.Amount : transaction.Amount;
    public string CounterParty { get; } = transaction.Counterparty;
    public string Note { get; } = transaction.Note;
}
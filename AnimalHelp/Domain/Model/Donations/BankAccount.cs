namespace AnimalHelp.Domain.Model.Donations;

public class BankAccount(string accountNumber, string owner)
{
    public string AccountNumber { get; set; } = accountNumber;
    public string Owner { get; set; } = owner;

    public BankAccount() : this("", "")
    {
    }
}
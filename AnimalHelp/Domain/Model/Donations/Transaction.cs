using System;

namespace AnimalHelp.Domain.Model.Donations;

public class Transaction : IEntity, IEquatable<Transaction>
{
    public string Id { get; set; }
    public DateTime DateTime { get; set; }
    public float Amount {  get; set; }
    public BankAccount Receiver { get; set; }
    public BankAccount Sender {  get; set; }
    public bool IsAnonymous {  get; set; }
    public Post? Post { get; set; }

    public Transaction(string id, DateTime dateTime, float amount, BankAccount receiver, BankAccount sender, bool isAnonymous = false, Post? post = null)
    {
        Id = id;
        DateTime = dateTime;
        Amount = amount;
        Receiver = receiver;
        Sender = sender;
        IsAnonymous = isAnonymous;
        Post = post;
    }

    public Transaction() : this("", DateTime.MinValue, 0.0f, new(), new())
    {
    }

    public bool Equals(Transaction? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Transaction)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
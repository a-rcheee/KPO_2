using KPO_2.Visitor;

namespace KPO_2.Entities;

public class Operation
{
    public Guid Id { get; private set; }
    public FinanceType Type { get; private set; }
    public Guid BankAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string? Description { get; private set; }
    public Guid CategoryId { get; private set; }

    internal Operation(Guid id, FinanceType type, Guid bankAccountId, decimal amount, DateTime date,
        Guid categoryId, string? description = null)
    {
        Id = id;
        Type = type;
        BankAccountId = bankAccountId;
        Amount = amount;
        Date = date;
        Description = description;
        CategoryId = categoryId;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
using KPO_2.Entities;

namespace KPO_2.Factory;

public interface IEntityFactory
{
    BankAccount CreateBankAccount(string name, decimal balance = 0);
    Category CreateCategory(FinanceType type, string name);
    Operation CreateOperation(FinanceType type, Guid bankAccount, decimal amount, DateTime date,
        Guid categoryId, string? description = null);
}
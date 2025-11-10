using KPO_2.Entities;

namespace KPO_2.Factory;

public class EntityFactory : IEntityFactory
{
    public BankAccount CreateBankAccount(string name, decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Начальный баланс не должен быть отрицательным");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя не должно быть пустым");
        }
        
        return new BankAccount(Guid.NewGuid(), name, balance);
        
    }

    public Category CreateCategory(FinanceType type, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new AggregateException("Имя не должно быть пустым");
        }

        return new Category(Guid.NewGuid(), type, name);
    }

    public Operation CreateOperation(FinanceType type, Guid bankAccount, decimal amount, DateTime date, Guid categoryId,
        string? description = null)
    {   
        if (amount <= 0)
        {
            throw new AggregateException("Сумма опрераций должна быть положительной");
        }

        if (bankAccount == Guid.Empty)
        {
            throw new ArgumentException("Неизвестный ID счёта");
        }

        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException("Неизвестный ID категории");
        }
        
        return new Operation(Guid.NewGuid(), type, bankAccount, amount, date, categoryId, description);
    }
}
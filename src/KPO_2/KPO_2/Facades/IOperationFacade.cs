using KPO_2.Entities;

namespace KPO_2.Facades;

public interface IOperationFacade
{
    Operation Create(FinanceType financeType, Guid accountId, decimal amount,
        DateTime date, Guid categoryId, string? description = null);
    void Delete(Guid id);
    List<Operation> List();
}
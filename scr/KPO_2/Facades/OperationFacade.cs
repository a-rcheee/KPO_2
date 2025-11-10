using KPO_2.Entities;
using KPO_2.Factory;
using KPO_2.Repository;

namespace KPO_2.Facades;

public class OperationFacade : IOperationFacade
{
    private readonly IEntityFactory _factory;
    private readonly IOperationRepository _operation;

    public OperationFacade(IEntityFactory factory, IOperationRepository operation)
    {
        _factory = factory;
        _operation = operation;
    }
    
    public Operation Create(FinanceType type, Guid accountId, decimal amount, DateTime date, Guid categoryId,
        string? description = null)
    {
        var operation = _factory.CreateOperation(type, accountId, amount, date, categoryId, description);
        _operation.Add(operation);
        return operation;
    }

    public void Delete(Guid id)
    {
        _operation.Delete(id);
    }
    

    public List<Operation> List()
    {
        var result = new List<Operation>();
        foreach (var a in _operation.GetAll())
        {
            result.Add(a);
        }
        return result;
    }
}
using KPO_2.Entities;

namespace KPO_2.Repository;

public class OperationRepository : IOperationRepository
{
    private readonly Dictionary<Guid, Operation> _operations = new();
    
    public void Add(Operation entity)
    {
        _operations[entity.Id] = entity;
    }

    public void Update(Operation entity)
    {
        _operations[entity.Id] = entity;
    }

    public void Delete(Guid id)
    {  
        _operations.Remove(id);
    }

    public Operation? Get(Guid id)
    {
        if (_operations.ContainsKey(id))
        {
            return _operations[id];
        }
        return null;
    }

    public List<Operation> GetAll()
    {
        return new List<Operation>(_operations.Values);
    }

    public List<Operation> GetByInterval(DateTime start, DateTime end)
    {
        var result = new List<Operation>();
        foreach (var a in _operations.Values)
        {
            if (a.Date >= start && a.Date <= end)
            {
                result.Add(a);
            }
        }
        return result;
    }

    public List<Operation> GetByCategory(Guid categoryId, DateTime startDate, DateTime? start = null, DateTime? end = null)
    {
        var result = new List<Operation>();
        foreach (var a in _operations.Values)
        {
            if (a.CategoryId == categoryId)
            {
                result.Add(a);
            }
        }
        return result;
    }

    public List<Operation> GetByType(FinanceType type, DateTime startDate, DateTime? start = null, DateTime? end = null)
    {
        var result = new List<Operation>();
        foreach (var a in _operations.Values)
        {
            if (a.Type == type)
            {
                result.Add(a);
            }
        }
        return result;
    }
}
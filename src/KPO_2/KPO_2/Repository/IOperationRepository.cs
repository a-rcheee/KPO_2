using KPO_2.Entities;

namespace KPO_2.Repository;

public interface IOperationRepository : IRepository<Operation>
{
    List<Operation> GetByInterval(DateTime start, DateTime end);
    List<Operation> GetByCategory(Guid categoryId, DateTime startDate, DateTime? start = null, DateTime? end = null);
    List<Operation> GetByType(FinanceType type, DateTime startDate, DateTime? start = null, DateTime? end = null);
}
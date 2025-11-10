using KPO_2.Entities;

namespace KPO_2.Repository;

public interface ICategoryRepository: IRepository<Category>
{
    List<Category> GetByType(FinanceType type);
}
using KPO_2.Entities;

namespace KPO_2.Facades;

public interface ICategoryFacade
{
    Category Create(FinanceType type, string name);
    void Rename(Guid id, string name);
    void Delete(Guid id);
    List<Category> List();
    List<Category> GetByType(FinanceType type);
}
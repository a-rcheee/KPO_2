using KPO_2.Entities;
using KPO_2.Factory;
using KPO_2.Repository;

namespace KPO_2.Facades;

public class CategoryFacade : ICategoryFacade
{
    private readonly IEntityFactory _factory;
    private readonly ICategoryRepository _category;

    public CategoryFacade(IEntityFactory factory, ICategoryRepository category)
    {
        _factory = factory;
        _category = category;
    }
    
    public Category Create(FinanceType type, string name)
    {
        var category = _factory.CreateCategory(type, name);
        _category.Add(category);
        return category;
    }

    public void Rename(Guid id, string name)
    {
        var category = _category.Get(id);
        if (category == null)
        {
            throw new KeyNotFoundException("Категория не найдена");
        }
        category.Rename(name);
        _category.Update(category);
    }

    public void Delete(Guid id)
    {
        _category.Delete(id);
    }

    public List<Category> List()
    {
        var result = new List<Category>();
        foreach (var a in _category.GetAll())
        {
            result.Add(a);            
        }
        return result;
    }

    public List<Category> GetByType(FinanceType type)
    {
        var result = new List<Category>();
        foreach (var a in _category.GetAll())
        {
            if (a.Type == type)
            {
                result.Add(a);
            }
        }
        return result;
    }
}
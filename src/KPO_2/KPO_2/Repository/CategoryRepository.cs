using KPO_2.Entities;

namespace KPO_2.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly Dictionary<Guid, Category> _categories = new();
    
    public void Add(Category entity)
    {
        _categories[entity.Id] = entity;
    }

    public void Update(Category entity)
    {
        _categories[entity.Id] = entity;
    }

    public void Delete(Guid id)
    {
        _categories.Remove(id);
    }

    public Category? Get(Guid id)
    {
        if (_categories.ContainsKey(id))
        {
            return _categories[id];
        }
        return null;
    }

    public List<Category> GetAll()
    {
        return new List<Category>(_categories.Values);
    }

    public List<Category> GetByType(FinanceType type)
    {
        var result = new List<Category>();
        foreach (var c in _categories.Values)
        {
            if (c.Type == type)
            {
                result.Add(c);
            }
        }
        return result;
    }
}
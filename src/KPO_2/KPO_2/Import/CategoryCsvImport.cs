using KPO_2.Entities;
using KPO_2.Repository;

namespace KPO_2.Import;

public class CategoryCsvImport : IImport
{
    private readonly ICategoryRepository _category;

    public CategoryCsvImport(ICategoryRepository categoryRepository)
    {
        _category = categoryRepository;
    }
    
    public int Import(string path)
    {
        var lines = File.ReadAllLines(path);
        int count = 0;
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            var parts = line.Split(',');
            if (parts.Length < 3)
            {
                continue;
            }
            var id = Guid.Parse(parts[0].Trim());
            var type = (FinanceType)Enum.Parse(typeof(FinanceType), parts[1].Trim());
            var name = parts[2].Trim();
            
            _category.Add(new Category(id, type, name));
            count++;
        }
        return count;
    }
}
using KPO_2.Entities;
using KPO_2.Facades;

namespace KPO_2.Commands;

public class DeleteCategoryCommand : ICommand
{
    private readonly ICategoryFacade _category;
    private readonly Guid _categoryId;

    public DeleteCategoryCommand(ICategoryFacade category, Guid categoryId)
    {
        _category = category;
        _categoryId = categoryId;
    }
    public void Execute()
    {
        try
        {
            _category.Delete(_categoryId);
            Console.WriteLine($"Удалена категория {_categoryId}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка {e}");
            throw;
        }
    }
}
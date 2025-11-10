using KPO_2.Entities;
using KPO_2.Facades;

namespace KPO_2.Commands;

public class CreateCategoryCommand : ICommand
{
    private readonly ICategoryFacade _facade;
    private readonly FinanceType _type;
    private readonly string _name;

    public CreateCategoryCommand(ICategoryFacade facade, FinanceType type, string name)
    {
        _facade = facade;
        _type = type;
        _name = name;
    }
    public void Execute()
    {
        var category = _facade.Create(_type, _name);
        Console.WriteLine($"Создана категория {category.Name} типа {_type}, с id {category.Id}");
    }
}
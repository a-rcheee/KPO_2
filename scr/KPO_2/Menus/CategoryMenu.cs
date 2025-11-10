using KPO_2.Entities;
using KPO_2.Facades;
using KPO_2.Repository;

namespace KPO_2.Menus;

public class CategoryMenu
{
    public static void Create(ICategoryFacade categories)
    {
        Console.WriteLine("Введите тип Income или Expense: ");
        FinanceType type;
        string? s = Console.ReadLine();
        while (!Enum.TryParse(s?.Trim(), true, out type))
        {
            Console.WriteLine("Введите тип Income или Expense: ");
            s = Console.ReadLine();
        }

        Console.Write("Имя категории: ");
        string? name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Пусто, повторите: ");
            name = Console.ReadLine();
        }
        name = name.Trim();
        
        var categry = categories.Create(type, name);
        Console.WriteLine($"Создана категория: {categry.Name}, id: {categry.Id}, тип: {categry.Type}");
    }

    public static void List(ICategoryRepository repository)
    {
        var list = repository.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("Категорий нет");
            return;
        }

        Console.WriteLine($"Категории {list.Count}: ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {list[i].Name}, {list[i].Type}, {list[i].Id}");
        }
    }
}
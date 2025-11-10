using KPO_2.Commands;
using KPO_2.Entities;
using KPO_2.Facades;
using KPO_2.Repository;

namespace KPO_2.Menus;

public class OperationMenu
{
    public static void Create(IOperationFacade operations,
        IBankAccountRepository accountRepository, ICategoryRepository categoryRepository)
    {
        FinanceType type;
        string? s = Console.ReadLine();
        while (!Enum.TryParse(s?.Trim(), true, out type))
        {
            Console.WriteLine("Введите тип Income или Expense: ");
            s = Console.ReadLine();
        }
        
        AccountMenu.List(accountRepository);
        Console.Write("Id счёта: ");
        Guid accountId;
        string? input = Console.ReadLine();
        while (!Guid.TryParse(input, out accountId))
        {
            Console.Write("Неверный Guid, повторите");
            input = Console.ReadLine();
        }
        
        CategoryMenu.List(categoryRepository);
        Console.Write("Id категории: ");
        Guid categoryId;
        input = Console.ReadLine();
        while (!Guid.TryParse(input, out categoryId))
        {
            Console.Write("Неверный Guid, повторите: ");
            input = Console.ReadLine();
        }
        
        Console.Write("Сумма: ");
        decimal amount;
        input = Console.ReadLine();
        while (!decimal.TryParse(input, out amount) || amount < 0)
        {
            Console.Write("Сумма должна быть неотрицательной, повторите: ");
            input = Console.ReadLine();
        }
        
        Console.Write("Дата (yyyy-mm-dd): ");
        DateTime date;
        input = Console.ReadLine();
        while (!DateTime.TryParse(input, out date))
        {
            Console.Write("Неверная дата, повторите: ");
            input = Console.ReadLine();
        }
        
        Console.Write("Описание: ");
        string? description = Console.ReadLine();
        var operation = operations.Create(type, accountId, amount, date, categoryId, description);
        Console.WriteLine($"Добавлена операция: {operation.Type} {operation.Amount} {operation.Date:yyyy-MM-dd}");
    }

    public static void List(IOperationFacade operations)
    {
        var list = operations.List();
        if (list.Count == 0)
        {
            Console.WriteLine("Операции не найдены");
            return;
        }
        Console.WriteLine($"Операции {list.Count}");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {list[i].Date:yyyy-MM-dd}, {list[i].Type}, {list[i].Amount}, {list[i].BankAccountId}, {list[i].CategoryId}");
        }
    }

    public static void Delete(ICommandInvoker invoker, IOperationFacade operations)
    {
        Console.Write("Id операции для удаления: ");
        Guid id;
        string? input = Console.ReadLine();
        while (!Guid.TryParse(input, out id))
        {
            Console.Write("Неверный Guid, повторите: ");
            input = Console.ReadLine();
        }
        
        invoker.Execute(new DeleteOperationCommand(operations, id));
        Console.WriteLine("Операция была удалена");
    }
}
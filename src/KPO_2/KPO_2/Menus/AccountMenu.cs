using KPO_2.Facades;
using KPO_2.Repository;

namespace KPO_2.Menus;

public class AccountMenu
{
    public static void Create(IBankAccountFacade accounts)
    {
        Console.WriteLine("Имя счёта: ");
        string? name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Неверный ввод, повторите: ");
        }

        name = name.Trim();
        Console.WriteLine("Начальный баланс: ");
        decimal balance;
        string? input = Console.ReadLine();
        while (!decimal.TryParse(input, out balance) || balance < 0)
        {
            Console.Write("Нужно ввести неторицательное число, попробуйте ещё раз: ");
            input = Console.ReadLine();
        }
        var account = accounts.Create(name, balance);
        Console.WriteLine($"Создан счёт: {account.Name}, id: {account.Id}, баланс: {account.Balance}");
    }

    public static void List(IBankAccountRepository repository)
    {
        var list = repository.GetAll();
        if (list.Count == 0)
        {
            Console.WriteLine("Счетов нет");
            return;
        }
        Console.WriteLine($"Счета {list.Count}:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {list[i].Name}, {list[i].Id}, {list[i].Balance}");
        }
    }
}
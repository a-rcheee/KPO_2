using KPO_2.Facades;

namespace KPO_2.Commands;

public class CreateAccountCommand : ICommand
{
    private readonly IBankAccountFacade _facade;
    private readonly string _name;
    private readonly decimal _balance;

    public CreateAccountCommand(IBankAccountFacade facade, string name, decimal balance = 0)
    {
        _facade = facade;
        _name = name;
        _balance = balance;
    }
    
    public void Execute()
    {
        var account = _facade.Create(_name, _balance);
        Console.WriteLine($"Создан счёт: {account.Name} (Id = {account.Id}, баланс = {account.Balance})");
    }

}
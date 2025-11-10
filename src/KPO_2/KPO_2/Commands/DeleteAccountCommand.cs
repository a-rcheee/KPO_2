using KPO_2.Facades;

namespace KPO_2.Commands;

public class DeleteAccountCommand : ICommand
{
    private readonly IBankAccountFacade _accounts;
    private readonly Guid _accountId;

    public DeleteAccountCommand(IBankAccountFacade accounts, Guid accountId)
    {
        _accounts = accounts;
        _accountId = accountId;
    }
    
    public void Execute()
    {
        try
        {
            _accounts.Delete(_accountId);
            Console.WriteLine($"Удалён счёт {_accountId}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка {e.Message}");
            throw;
        }
    }
}
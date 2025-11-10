using KPO_2.Entities;
using KPO_2.Factory;
using KPO_2.Repository;

namespace KPO_2.Facades;

public class BankAccountFacade : IBankAccountFacade
{
    private readonly IEntityFactory _factory;
    private readonly IBankAccountRepository _account;

    public BankAccountFacade(IEntityFactory factory, IBankAccountRepository account)
    {
        _factory = factory;
        _account = account;
    }

    public BankAccount Create(string name, decimal balance = 0)
    {
        var account = _factory.CreateBankAccount(name, balance);
        _account.Add(account);
        return account;
    }

    public void Rename(Guid id, string name)
    {
        var account = _account.Get(id);
        if (account == null)
        {
            throw new KeyNotFoundException("Счёт не найден");
        }

        account.Rename(name);
        _account.Update(account);
    }

    public void Delete(Guid id)
    {
        _account.Delete(id);
    }

    public List<BankAccount> List()
    {
        var result = new List<BankAccount>();
        foreach (var a in _account.GetAll())
        {
            result.Add(a);
        }

        return result;
    }
}
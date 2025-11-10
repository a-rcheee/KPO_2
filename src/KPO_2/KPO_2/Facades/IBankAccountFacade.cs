using KPO_2.Entities;

namespace KPO_2.Facades;

public interface IBankAccountFacade
{
    BankAccount Create(string name, decimal balance = 0);
    void Rename(Guid id, string name);
    void Delete(Guid id);
    List<BankAccount> List();
}
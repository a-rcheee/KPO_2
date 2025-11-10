using KPO_2.Entities;

namespace KPO_2.Repository;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly Dictionary<Guid, BankAccount> _accounts = new();

    public void Add(BankAccount entity)
    {
        _accounts[entity.Id] = entity;
    }

    public void Update(BankAccount entity)
    {
        _accounts[entity.Id] = entity;
    }

    public void Delete(Guid id)
    {
        _accounts.Remove(id);
    }

    public BankAccount? Get(Guid id)
    {
        if (_accounts.ContainsKey(id))
        {
            return _accounts[id];
        }
        return null;
    }

    public List<BankAccount> GetAll()
    {
        return new List<BankAccount>(_accounts.Values);
    }
    
}
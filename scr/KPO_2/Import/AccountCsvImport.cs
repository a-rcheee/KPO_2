using KPO_2.Entities;
using KPO_2.Repository;

namespace KPO_2.Import;

public class AccountCsvImport : IImport
{
    private readonly IBankAccountRepository _accounts;

    public AccountCsvImport(IBankAccountRepository accounts)
    {
        _accounts = accounts;
    }
    
    public int Import(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }
        var lines = File.ReadAllLines(path);
        int count = 0;
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            var parts = line.Split(',');
            if (parts.Length < 3)
            {
                continue;
            }
            var id = Guid.Parse(parts[0].Trim());
            var name = parts[1].Trim();
            var balance = decimal.Parse(parts[2].Trim());
            var account = new BankAccount(id, name, balance);
            _accounts.Add(account);
            count++;
        }
        return count;
    }
}
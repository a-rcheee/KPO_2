using KPO_2.Entities;
using KPO_2.Repository;

namespace KPO_2.Import;

public class OperationCsvImport : IImport
{
    private readonly IOperationRepository _operation;

    public OperationCsvImport(IOperationRepository operation)
    {
        _operation = operation;
    }
    
    public int Import(string path)
    {
        var lines = File.ReadAllLines(path);
        int count = 0;
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            var parts = line.Split(",");
            if (parts.Length < 6)
            {
                continue;
            }
            var id = Guid.Parse(parts[0].Trim());
            var type = (FinanceType)Enum.Parse(typeof(FinanceType), parts[1].Trim());
            var accountId = Guid.Parse(parts[2].Trim());
            var amount = decimal.Parse(parts[3].Trim());
            var date = DateTime.Parse(parts[4].Trim());
            var categoryId = Guid.Parse(parts[5].Trim());
            string? description = null;
            if (parts.Length > 6)
            {
                description = parts[6].Trim();
            }
            _operation.Add(new Operation(id, type, accountId, amount, date, categoryId, description));
            count++;
        }
        return count;
    }
}
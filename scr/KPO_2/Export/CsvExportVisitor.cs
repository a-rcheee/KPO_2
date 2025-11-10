using System.Text;
using KPO_2.Entities;
using KPO_2.Visitor;

namespace KPO_2.Export;

public class CsvExportVisitor : IVisitor
{
    private readonly StringBuilder _accounts = new StringBuilder("id,name,balance\n");
    private readonly StringBuilder _category = new StringBuilder("id,type,name\n");
    private readonly StringBuilder _operations = new StringBuilder("id,type,accountId,amount,date,categoryId,description\n");

    public string GetAccountsCsv()
    {
        return _accounts.ToString();
    }

    public string GetCategoryCsv()
    {
        return _category.ToString();
    }

    public string GetOperationsCsv()
    {
        return _operations.ToString();
    }

    public void Visit(BankAccount account)
    {
        _accounts.AppendLine($"{account.Id},{account.Name},{account.Balance}");
    }

    public void Visit(Category category)
    {
        _category.AppendLine($"{category.Id},{category.Type}, {category.Name}");
    }

    public void Visit(Operation operation)
    {
        var description = operation.Description;
        if (description == null)
        {
            description = string.Empty;
        }
        _operations.AppendLine($"{operation.Id},{operation.Type},{operation.BankAccountId},{operation.Amount},{operation.Date},{operation.CategoryId},{description}");
    }
}
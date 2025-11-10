using System.Text.Json;
using KPO_2.Entities;
using KPO_2.Visitor;

namespace KPO_2.Export;

public class JsonExportVisitor : IVisitor
{
    private readonly List<object> _item = new List<object>();
    public void Visit(BankAccount account)
    {
        _item.Add(new
        {
            Type = "Account",
            id = account.Id,
            name = account.Name,
            balance = account.Balance,
        });
    }

    public void Visit(Category category)
    {
        _item.Add(new
        {
            Type = "Category",
            id = category.Id,
            categoryType = category.Type.ToString(),
            name = category.Name,
        });
    }

    public void Visit(Operation operation)
    {
        _item.Add(new
        {
            Type = "Operation",
            id = operation.Id,
            operationType = operation.Type.ToString(),
            bankAccountId = operation.BankAccountId,
            anount = operation.Amount,
            date = operation.Date,
            description = operation.Description,
            categoryId = operation.CategoryId,
        });
    }

    public string GetJson()
    {
        return JsonSerializer.Serialize(_item);
    }
}
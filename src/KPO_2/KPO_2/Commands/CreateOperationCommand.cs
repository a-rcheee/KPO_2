using KPO_2.Entities;
using KPO_2.Facades;

namespace KPO_2.Commands;

public class CreateOperationCommand : ICommand
{
    private readonly IOperationFacade _operation;
    private readonly FinanceType _type;
    private readonly Guid _accountId;
    private readonly decimal _amount;
    private readonly DateTime _date;
    private readonly Guid _categoryId;
    private readonly string? _description;

    public CreateOperationCommand(IOperationFacade operation, FinanceType type,
        Guid accountId, decimal amount, DateTime date,
        Guid categoryId, string? description)
    {
        _operation = operation;
        _type = type;
        _accountId = accountId;
        _amount = amount;
        _date = date;
        _categoryId = categoryId;
        _description = description;
    }
    public void Execute()
    {
        try
        {
            var operation = _operation.Create(_type, _accountId, _amount, _date, _categoryId, _description);
            Console.WriteLine($"Добавлено: {operation.Type} {operation.Amount} {operation.Date:yyyy-MM-dd}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
            throw;
        }
    }
}
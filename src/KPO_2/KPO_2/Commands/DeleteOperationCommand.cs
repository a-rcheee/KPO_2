using KPO_2.Facades;

namespace KPO_2.Commands;

public class DeleteOperationCommand : ICommand
{
    private readonly IOperationFacade _operation;
    private readonly Guid _operationId;

    public DeleteOperationCommand(IOperationFacade operation, Guid operationId)
    {
        _operation = operation;
        _operationId = operationId;
    }
    
    public void Execute()
    {
        _operation.Delete(_operationId);
        Console.WriteLine($"Удалена операция: id = {_operationId}");
    }
}
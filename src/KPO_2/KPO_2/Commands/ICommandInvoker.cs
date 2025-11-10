namespace KPO_2.Commands;

public interface ICommandInvoker
{
    void Execute(ICommand command);
}
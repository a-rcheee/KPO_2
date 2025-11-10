namespace KPO_2.Commands;

public class CommandInvoker : ICommandInvoker
{
    public void Execute(ICommand command)
    {
        command.Execute();
    }
}
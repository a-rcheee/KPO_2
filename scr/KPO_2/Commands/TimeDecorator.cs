using System.Diagnostics;

namespace KPO_2.Commands;

public class TimeDecorator : ICommand
{
    private readonly ICommand _cmd;

    public TimeDecorator(ICommand cmd)
    {
        _cmd = cmd;
    }
        
    public void Execute()
    {
        var stop = Stopwatch.StartNew();
        try
        {
            _cmd.Execute();
        }
        finally
        {
            stop.Stop();
            Console.WriteLine($"Время: {stop.ElapsedMilliseconds} мс");
        }
    }
}
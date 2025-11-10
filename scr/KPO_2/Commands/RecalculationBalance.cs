using KPO_2.Facades;
using KPO_2.Repository;

namespace KPO_2.Commands;

public class RecalculationBalance : ICommand
{
    private readonly IAnalyticsFacade _analytics;
    private readonly IBankAccountRepository _accounts;

    public RecalculationBalance(IAnalyticsFacade analytics, IBankAccountRepository accounts)
    {
        _analytics = analytics;
        _accounts = accounts;
    }
    public void Execute()
    {
        _analytics.Recalculate(_accounts);
        Console.WriteLine("Баланс пересчитан");
    }
}
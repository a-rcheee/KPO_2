using KPO_2.Commands;
using KPO_2.Facades;
using KPO_2.Repository;

namespace KPO_2.Menus;

public class AnalyticsMenu
{
    public static void Recalc(ICommandInvoker invoker, IAnalyticsFacade analytics,
        IBankAccountRepository accountRepository)
    {
        invoker.Execute(new RecalculationBalance(analytics, accountRepository));
    }
}
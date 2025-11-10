using KPO_2.Entities;
using KPO_2.Repository;

namespace KPO_2.Facades;

public interface IAnalyticsFacade
{
    decimal Deficit(DateTime start, DateTime end);
    Dictionary<FinanceType, decimal> TotalsByType(DateTime start, DateTime end);
    void Recalculate(IBankAccountRepository account);
}
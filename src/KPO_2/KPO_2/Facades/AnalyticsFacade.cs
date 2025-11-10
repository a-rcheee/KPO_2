using KPO_2.Entities;
using KPO_2.Repository;

namespace KPO_2.Facades;

public class AnalyticsFacade : IAnalyticsFacade
{
    private readonly IOperationRepository _operations;
    private readonly ICategoryRepository _categories;

    public AnalyticsFacade(IOperationRepository operations, ICategoryRepository categories)
    {
        _operations = operations;
        _categories = categories;
    }
    
    public decimal Deficit(DateTime start, DateTime end)
    {
        decimal income = 0;
        decimal expense = 0;
        var list = _operations.GetByInterval(start, end);
        for (int i = 0; i < list.Count; i++)
        {
            var operation = list[i];
            if (operation.Type == FinanceType.Income)
            {
                income += operation.Amount;
            }
            else
            {
                expense += operation.Amount;
            }
        }
        return income - expense;
    }

    public Dictionary<FinanceType, decimal> TotalsByType(DateTime start, DateTime end)
    {
        var totals = new Dictionary<FinanceType, decimal>();
        totals[FinanceType.Income] = 0;
        totals[FinanceType.Expense] = 0;
        var list = _operations.GetByInterval(start, end);
        for (int i = 0; i < list.Count; i++)
        {
            var operation = list[i];
            totals[operation.Type] = operation.Amount + totals[operation.Type];
        }
        return totals;
    }

    public void Recalculate(IBankAccountRepository accounts)
    {
     var result = new Dictionary<Guid, decimal>();
     var operations = _operations.GetAll();

     for (int i = 0; i < operations.Count; i++)
     {
         var operation = operations[i];
         decimal res = 0;
         if (result.ContainsKey(operation.BankAccountId))
         {
             res = result[operation.BankAccountId];
         }

         if (operation.Type == FinanceType.Income)
         {
             res += operation.Amount;
         }
         else
         {
             res -= operation.Amount;
         }
         result[operation.BankAccountId] = res;
     }
     
     var accs = accounts.GetAll();
     for (int i = 0; i < accs.Count; i++)
     {
         var account = accs[i];
         decimal resultBalance = result.ContainsKey(account.Id) ? result[account.Id] : 0;
         decimal diff = resultBalance - account.Balance;

         if (diff > 0)
         {
             account.UpgradeBalance(diff);
         }
         else if (diff < 0)
         {
             account.ReduceBalance(-diff);
         }
         accounts.Update(account);
     }
    }
}
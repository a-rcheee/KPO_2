using KPO_2.Commands;
using KPO_2.Export;
using KPO_2.Facades;
using KPO_2.Factory;
using KPO_2.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace KPO_2.DI;

public static class FinanceService
{
    public static IServiceCollection AddFinanceServices(this IServiceCollection services)
    {
        services.AddSingleton<IEntityFactory, EntityFactory>();
        services.AddSingleton<IBankAccountRepository, BankAccountRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        services.AddSingleton<IOperationRepository, OperationRepository>();
        
        services.AddSingleton<IBankAccountFacade, BankAccountFacade>();
        services.AddSingleton<ICategoryFacade, CategoryFacade>();
        services.AddSingleton<IOperationFacade, OperationFacade>();
        services.AddSingleton<IAnalyticsFacade, AnalyticsFacade>();
        
        services.AddSingleton<ICommandInvoker, CommandInvoker>();
        return services;
    }
}
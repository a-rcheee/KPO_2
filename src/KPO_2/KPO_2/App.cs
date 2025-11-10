using KPO_2.Commands;
using KPO_2.Dto;
using KPO_2.Facades;
using KPO_2.Menus;
using KPO_2.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace KPO_2;

public static class App
{
    public static void Run(ServiceProvider serviceProvider)
    {
        var accountFacade = serviceProvider.GetRequiredService<IBankAccountFacade>();
        var categoryFacade = serviceProvider.GetRequiredService<ICategoryFacade>();
        var operationFacade = serviceProvider.GetRequiredService<IOperationFacade>();
        var analitics = serviceProvider.GetRequiredService<IAnalyticsFacade>();
        var accountRepository = serviceProvider.GetRequiredService<IBankAccountRepository>();
        var categoryRepository = serviceProvider.GetRequiredService<ICategoryRepository>();
        var operationRepository = serviceProvider.GetRequiredService<IOperationRepository>();
        var invoker = serviceProvider.GetRequiredService<ICommandInvoker>();

        bool exit = false;
        while (!exit)
        {
            Menu.Print();
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AccountMenu.Create(accountFacade);
                    break;
                case "2":
                    AccountMenu.List(accountRepository);
                    break;
                case "3":
                    CategoryMenu.Create(categoryFacade);
                    break;
                case "4":
                    CategoryMenu.List(categoryRepository);
                    break;
                case "5":
                    OperationMenu.Create(operationFacade, accountRepository, categoryRepository);
                    break;
                case "6":
                    OperationMenu.List(operationFacade);
                    break;
                case "7":
                    OperationMenu.Delete(invoker, operationFacade);
                    break;
                case "8":
                    AnalyticsMenu.Recalc(invoker, analitics, accountRepository);
                    break;
                case "9":
                    ExportImport.ExportJson(accountRepository, categoryRepository, operationRepository);
                    break;
                case "10":
                    ExportImport.ExportCsvVisitor(accountRepository, categoryRepository, operationRepository);
                    break;
                case "11":
                    ExportImport.ImportCsv(accountRepository, categoryRepository, operationRepository);
                    break;
                case "12":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Такой команды нет");
                    break;
            }
            Console.WriteLine();
        }
        Console.WriteLine("Заходите ещё! ^^");
    }
}
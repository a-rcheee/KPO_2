using KPO_2.Export;
using KPO_2.Import;
using KPO_2.Repository;

namespace KPO_2;

public class ExportImport
{
    public static void ExportJson(IBankAccountRepository accountRepository,
        ICategoryRepository categoryRepository, IOperationRepository operationRepository)
    {
        var visitor = new JsonExportVisitor();
        var accounts = accountRepository.GetAll();
        for (int i = 0; i < accounts.Count; i++)
        {
            accounts[i].Accept(visitor);
        }
        
        var categories = categoryRepository.GetAll();
        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].Accept(visitor);
        }
        
        var operations = operationRepository.GetAll();
        for (int i = 0; i < operations.Count; i++)
        {
            operations[i].Accept(visitor);
        }

        var json = visitor.GetJson();
        File.WriteAllText("export.json", json);
        
        Console.WriteLine("json экспорт файла в export.json");
    }

    public static void ExportCsvVisitor(IBankAccountRepository accountRepository,
        ICategoryRepository categoryRepository, IOperationRepository operationRepository)
    {
        var visitor = new CsvExportVisitor();
        var accounts = accountRepository.GetAll();
        for (int i = 0; i < accounts.Count; i++)
        {
            accounts[i].Accept(visitor);
        }
        
        var categories = categoryRepository.GetAll();
        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].Accept(visitor);
        }
        
        var operations = operationRepository.GetAll();
        for (int i = 0; i < operations.Count; i++)
        {
            operations[i].Accept(visitor);
        }
        
        File.WriteAllText("accounts.csv", visitor.GetAccountsCsv());
        File.WriteAllText("categories.csv", visitor.GetCategoryCsv());
        File.WriteAllText("operations.csv", visitor.GetOperationsCsv());
        Console.WriteLine("csv экспорт файлов accounts.csv, categories.csv, operations.csv");
    }

    public static void ImportCsv(IBankAccountRepository accountRepository,
        ICategoryRepository categoryRepository, IOperationRepository operationRepository)
    {
        int total = 0;
        try
        {
            var accImport = new AccountCsvImport(accountRepository);
            var n = accImport.Import("accounts.csv");
            Console.WriteLine("account.csv: " + n);
            total += n;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка account.csv " + ex.Message);
        }

        try
        {
            var catImport = new CategoryCsvImport(categoryRepository);
            var n = catImport.Import("categories.csv");
            Console.WriteLine("categories.csv: " + n);
            total += n;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка categories.csv" + e);
        }

        try
        {
            var operImport = new OperationCsvImport(operationRepository);
            var n = operImport.Import("operations.csv");
            Console.WriteLine("operations.csv: " + n);
            total += n;
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка operations.csv " + e.Message);
        }
        Console.WriteLine("Импорт завершён, суммарно записей: " + total);
    }
}
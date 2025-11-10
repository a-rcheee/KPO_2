using KPO_2.DI;
using Microsoft.Extensions.DependencyInjection;

namespace KPO_2;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection().AddFinanceServices();
        var serviceProvider = services.BuildServiceProvider();
        App.Run(serviceProvider);
    }
}
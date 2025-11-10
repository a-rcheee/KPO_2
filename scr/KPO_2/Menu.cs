namespace KPO_2;

public static class Menu
{
    public static void Print()
    {
        Console.WriteLine("Выберите номер действия:");
        Console.WriteLine("1. Создать счёт");
        Console.WriteLine("2. Показать счета");
        Console.WriteLine("3. Создать категорию");
        Console.WriteLine("4. Показать категорию");
        Console.WriteLine("5. Создать операцию");
        Console.WriteLine("6. Показать операцию");
        Console.WriteLine("7. Удалить операцию");
        Console.WriteLine("8. Пересчитать баланс");
        Console.WriteLine("9. Экспорт json");
        Console.WriteLine("10. Экспорт csv");
        Console.WriteLine("11. Импорт csv");
        Console.WriteLine("12. Выход");
    }
}
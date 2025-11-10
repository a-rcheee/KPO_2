# KPO_2

## Проект реализует банковскую систему 
Реализовано:
1. Управление банковскими счетами (BankAccount), категориями (Category) и операциями (Operation)
2. Создание и вывод списков для счётов, категорий и операций
3. Удаление операций
   
4. Аналитика: \
  ● Deficit(start, end) - разница доходов и расходов за период \
  ● TotalsByType(start, end) - суммы по типам операций за период \
  ● Recalculate(...) - пересчёт балансов всех счётов
   
5. Импорт и экспорт: \
  ● По умолчанию все файлы читаются и записываются в рабочую папку сборки приложения: src\KPO_2\KPO_2\bin\Debug\net8.0 \
  ● Экспорт JSON всех сущностей \
  ● Экспорт CSV в 3 файла \
  ● Импорт CSV из 3 файлов \
  ● Импорт JSON и YAML, а также экспорт YAML пропущены, так как условие разрешает пропускать любые подпункты
6. Измерение времени для любой команды (TimeDecorator)

# Соблюдение принципов SOLID
## S (Single Responsibility)

1. Facades - инкапсулируют логику в своей области: BankAccountFacade, CategoryFacade, OperationFacade, AnalyticsFacade.
Каждый фасад отвечает только за операции своего модуля.
2. Factory - единая точка создания доменных объектов EntityFactory.
3. Repositories - только хранение и выборки: BankAccountRepository, CategoryRepository, OperationRepository.

## O (Open/Closed)

1. Добавить новый формат экспорта или импорта можно через новый Visitor/Importer без правок доменных классов
2. Интерфейсы репозиториев легко позволяют менять реализацию работы с БД без изменения другого кода

## L (Liskov Substitution)
Везде реализация через абстракции: IBankAccountRepository, ICategoryRepository, IOperationRepository, IEntityFactory, ICommand, ICommandInvoker, IVisitor, IImport

## I (Interface Segregation)
Отдельные интерфейсы для репозиториев, фасадов, команд, импорта и визитора

## D (Dependency Inversion)
Зависимости настраиваются через DI-контейнер: FinanceService. В коде верхнего уровня используются интерфейсы, а не конкретные классы

# Соблюдение принципов GRASP

## High Cohesion

Каждый класс делает одну вещь, например, репозитории только хранят и выдают сущности, фасады собирают шаги для дейтсвий, в импорте читается CSV, а визиторы только формируют текст для экспорта

## Low Coupling

Меню знает только про фасады, а фасады только про интерфейсы репозиториев, поэтому части мало зависят друг от друга

## Controller

За начальную точку отвечает App.cs. Конкретные действия пользователя, которые читают ввод и вызывают фасады или команды, принимают AccountMenu, CategoryMenu, OperationMenu и AnalyticsMenu

## Creator

Создание доменных объектов вынесено в EntityFactory

## Information Expert

Считать итоги и разницу AnalyticsFacade, где он берет операции из IOperationRepository.

## Polymorphism

Любые команды запускаются одинаково через ICommand и CommandInvoker, а TimeDecorator оборачивает любую из них

# Реализованные паттерны

## Factory

EntityFactory создаёт BankAccount, Category, Operation. Нужен для корректного и единообразного создания, а ткже для простой валидации при создании

## Facade

BankAccountFacade, CategoryFacade, OperationFacade, AnalyticsFacade упрощают работу с доменной моделью и CRUD, а также уменьшают связность

## Command

DeleteOperationCommand, RecalculationBalance, интерфейсы ICommand, ICommandInvoker инкапсулируют пользовательские действия как объекты и позволяют легко добавлять обёртки, как тот же замер времени

## Decorator

TimeDecorator является единым местом для измерения времени выполнения сценариев, благодаря чему ничего не изменяем в коде при оборачивании

## Repository

BankAccountRepository, CategoryRepository, OperationRepository инкапсулируют доступ к данным, приэтом ещё изолируя приложение от деталей хранения, благодаря чему позволяет потом заменить хранилище

## Visitor

IVisitor, JsonExportVisitor и CsvExportVisitor сущности вызывают Accept, а визиторы добавляют операцию экспорта сразу ко всему классе, приэтом не меняя сами сущности

## Dependency Injection

FinanceService все сервисы, репозитории, фасады и команды инициализируются в DI и он же инициализирует все сервисы

## Требования для запуска:
1) .NET 8.0 SDK.
2) NuGet: Microsoft.Extensions.DependencyInjection

## Инструкция по запуску
1) Стандартно, с помощью ide (рекомендуется Rider):
Откройте файл решения -> Открыть корневой проект KPO_2 -> Нажмите Run
2) Через терминал:
   Соберите решение: dotnet build
   Запустите через терминал: dotnet run --project src/KPO_2/KPO_2.csproj

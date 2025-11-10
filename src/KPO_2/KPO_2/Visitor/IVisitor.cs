using KPO_2.Entities;

namespace KPO_2.Visitor;

public interface IVisitor
{
    void Visit(BankAccount account);
    void Visit(Category category);
    void Visit(Operation operation);
}
using KPO_2.Visitor;

namespace KPO_2.Entities;

public class Category
{
   public Guid Id { get; private set; }
   public FinanceType Type { get; private set; }
   public string Name { get; private set; }

   internal Category(Guid id, FinanceType type, string name)
   {
      Id = id;
      Type = type;
      Name = name;
   }

   public void Rename(string name)
   {
      if (string.IsNullOrWhiteSpace(name))
      {
         throw new ArgumentException("Имя не должно быть пустым");
      }
      Name = name;
   }

   public void Accept(IVisitor visitor)
   {
      visitor.Visit(this);
   }
}
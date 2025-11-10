using KPO_2.Visitor;

namespace KPO_2.Entities;

public class BankAccount
{
   public Guid Id { get; private set; }
   public string Name { get; private set; }
   public decimal Balance { get; private set; }

   internal BankAccount(Guid id, string name, decimal balance)
   {
      Id = id;
      Name = name;
      Balance = balance;
   }

   public void Rename(string newName)
   {
      if (string.IsNullOrWhiteSpace(newName))
      {
         throw new ArgumentException("Имя аккаунта не должно быть пустым");
      }
      Name = newName;
   }

   public void UpgradeBalance(decimal amount)
   {
      if (amount <= 0)
      {
         throw new ArgumentException("Баланс не должен быть отрицательным");
      }
      Balance += amount;
   }

   public void ReduceBalance(decimal amount)
   {
      if (amount <= 0)
      {
         throw new ArgumentException("Баланс не должен быть отрицательным");
      }
      Balance -= amount;
   }

   public void Accept(IVisitor visitor)
   {
      visitor.Visit(this);
   }
}
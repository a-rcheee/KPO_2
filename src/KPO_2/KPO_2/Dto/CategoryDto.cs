using KPO_2.Entities;

namespace KPO_2.Dto;

public class CategoryDto
{
    public Guid Id { get; set; }
    public FinanceType Type {get; set;}
    public string? Name { get; set; }
}
using KPO_2.Entities;

namespace KPO_2.Dto;

public class OperationDto
{
    public Guid Id { get; set; }
    public FinanceType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
    public string? Description { get; set; }
}
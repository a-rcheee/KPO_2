using KPO_2.Entities;

namespace KPO_2.Dto;

public class DataFile
{
    public AccountDto[]? Accounts { get; set; }
    public CategoryDto[]? Categories { get; set; }
    public OperationDto[]? Operations { get; set; }
}
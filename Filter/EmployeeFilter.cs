namespace EMS.Filter;

public record EmployeeFilter : BaseFilter
{
    public string? Name { get; init; }
    public int? Age { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
}
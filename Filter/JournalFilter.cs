namespace EMS.Filter;

public record JournalFilter : BaseFilter
{
    public double? Salary { get; init; }
    public bool? IsApsent { get; init; }
    public int? EmployeeId { get; init; }
}
namespace EMS.Entities;

public class EmployeeWithJournal
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int EmployeeId { get; set; }
    public bool IsApsent { get; set; }
    public DateTime Data { get; set; }
    public int? AmountOfLating { get; set; }
    public string? Comment { get; set; }
}
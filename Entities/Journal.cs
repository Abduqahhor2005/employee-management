using System.ComponentModel.DataAnnotations;

namespace EMS.Entities;

public class Journal : BaseEntity
{
    public int EmployeeId { get; set; }
    public bool IsApsent { get; set; }
    public DateTime Data { get; set; }
    public int? AmountOfLating { get; set; }
    public string? Comment { get; set; }
}
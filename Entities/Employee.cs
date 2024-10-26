namespace EMS.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public List<Journal> Journals { get; set; } = [];
}
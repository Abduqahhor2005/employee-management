namespace EMS.DTOs;

public readonly record struct ReadJournal(
    int Id, int EmployeeId, bool IsApsent, DateTime Data, int? AmountOfLating, string? Comment);

public readonly record struct CreateJournal(
    int EmployeeId, bool IsApsent, DateTime Data, int? AmountOfLating, string? Comment);

public readonly record struct UpdateJournal(
    int Id, int EmployeeId, bool IsApsent, DateTime Data, int? AmountOfLating, string? Comment);
namespace EMS.DTOs;

public readonly record struct ReadEmployee(int Id, string Name, int Age, string Email, string PhoneNumber);

public readonly record struct CreateEmployee(string Name, int Age, string Email, string PhoneNumber);

public readonly record struct UpdateEmployee(int Id, string Name, int Age, string Email, string PhoneNumber);
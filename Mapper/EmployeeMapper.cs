using EMS.DTOs;
using EMS.Entities;

namespace EMS.Mapper;

public static class EmployeeMapper
{
    public static ReadEmployee ReadToEmployee(this Employee employee)
        => new ReadEmployee()
        {
            Id = employee.Id,
            Name = employee.Name,
            Age = employee.Age,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };
    public static Employee UpdateToEmployee(this Employee employee, UpdateEmployee updateEmployee)
    {
        employee.Id = updateEmployee.Id;
        employee.Name = updateEmployee.Name;
        employee.Age = updateEmployee.Age;
        employee.Email = updateEmployee.Email;
        employee.PhoneNumber = updateEmployee.PhoneNumber;
        employee.UpdatedAt = DateTime.UtcNow;
        return employee;
    }

    public static Employee CreateToEmployee(this CreateEmployee createEmployee)
        => new Employee()
        {
            Name = createEmployee.Name,
            Age = createEmployee.Age,
            Email = createEmployee.Email,
            PhoneNumber = createEmployee.PhoneNumber
        };

    public static Employee DeleteToEmployee(this Employee employee)
    {
        employee.IsDeleted = true;
        employee.DeletedAt = DateTime.UtcNow;
        employee.UpdatedAt = DateTime.UtcNow;
        return employee;
    }
}
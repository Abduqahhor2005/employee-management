using EMS.DTOs;
using EMS.Entities;
using EMS.Filter;
using EMS.Response;

namespace EMS.Service.Employee;

public interface IEmployeeService
{
    PaginationResponse<IEnumerable<ReadEmployee>> GetAllEmployees(EmployeeFilter filter);
    EmployeeSalary? GetEmployeeSalary(int id, DateTime date);
    IEnumerable<EmployeeWithJournal> GetAllEmployeesWithJournal();
    IEnumerable<EmployeeWithJournal> GetAllEmployeesWithJournalInCurrentMonth();
    IEnumerable<EmployeeWithJournalCount> GetAllEmployeesWithJournalCount();
    IEnumerable<EmployeesWithExperience> GetEmployeesWithExperience();
    ReadEmployee? GetEmployeeById(int id);
    bool CreateEmployee(CreateEmployee employee);
    bool UpdateEmployee(UpdateEmployee employee);
    bool DeleteEmployee(int id);
}
using EMS.DTOs;
using EMS.Entities;
using EMS.Filter;
using EMS.Mapper;
using EMS.Response;

namespace EMS.Service.Employee;

public class EmployeeService(DataContext context) : IEmployeeService
{
    public PaginationResponse<IEnumerable<ReadEmployee>> GetAllEmployees(EmployeeFilter filter)
    {
        IQueryable<Entities.Employee> employees = context.Employees;
        if (filter.Name != null)
            employees = employees.Where(x => x.Name.ToLower()
                .Contains(filter.Name.ToLower()));
        if (filter.Age != null)
            employees = employees.Where(x => x.Age == filter.Age);
        if (filter.Email != null)
            employees = employees.Where(x => x.Email!.ToLower()
                .Contains(filter.Email.ToLower()));
        if (filter.PhoneNumber != null)
            employees = employees.Where(x => x.PhoneNumber!.ToLower()
                .Contains(filter.PhoneNumber.ToLower()));
        IQueryable<ReadEmployee> result = employees.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).Select(x=>x.ReadToEmployee());
        int totalRecords = context.Employees.Count();
        return PaginationResponse<IEnumerable<ReadEmployee>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
    }
    
    public IEnumerable<EmployeeWithJournal> GetAllEmployeesWithJournal()
    {
        var employees = from e in context.Employees
            join j in context.Journals on e.Id equals j.EmployeeId
            select new EmployeeWithJournal()
            {
                Name = e.Name,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                EmployeeId = j.EmployeeId,
                IsApsent = j.IsApsent,
                Data = j.Data,
                AmountOfLating = j.AmountOfLating,
                Comment = j.Comment
            };
        return employees;
    }
    
    public IEnumerable<EmployeeWithJournal> GetAllEmployeesWithJournalInCurrentMonth()
    {
        var employees = from e in context.Employees
            join j in context.Journals on e.Id equals j.EmployeeId
            where j.Data.Month == DateTime.UtcNow.Month && j.Data.Year == DateTime.UtcNow.Year
            select new EmployeeWithJournal()
            {
                Name = e.Name,
                Age = e.Age,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                EmployeeId = j.EmployeeId,
                IsApsent = j.IsApsent,
                Data = j.Data,
                AmountOfLating = j.AmountOfLating,
                Comment = j.Comment
            };
        return employees;
    }
    
    public IEnumerable<EmployeeWithJournalCount> GetAllEmployeesWithJournalCount()
    {
        var employees = from e in context.Employees
            select new EmployeeWithJournalCount()
            {
                Name = e.Name,
                Count = e.Journals.Count
            };
        return employees;
    }
    
    public IEnumerable<EmployeesWithExperience> GetEmployeesWithExperience()
    {
        var employees = from e in context.Employees
                .Where(e => e.Age > 30 && e.Journals.Count > 5)
            select new EmployeesWithExperience()
            {
                Name = e.Name,
                Age = e.Age,
                Count = e.Journals.Count
            };
        return employees;
    }

    public ReadEmployee? GetEmployeeById(int id)
    {
        var employee = (from u in context.Employees
            where u.IsDeleted == false && u.Id==id
            select u.ReadToEmployee()).FirstOrDefault();
        return employee;
    }
    public EmployeeSalary? GetEmployeeSalary(int id, DateTime date)
    {
        var employee = (from u in context.Employees
            where u.IsDeleted == false && u.Id==id
            select new EmployeeSalary()
        {
            Name = u.ReadToEmployee().Name,
            Salary = date.Day*1000  
        }).FirstOrDefault();
        return employee;
    }

    public bool CreateEmployee(CreateEmployee employee)
    {
        bool existEmployee = context.Employees.Any(x =>
            x.Email.ToLower() == employee.Email.ToLower() && x.IsDeleted == false);
        if (existEmployee) return false;
        context.Employees.Add(employee.CreateToEmployee());
        context.SaveChanges();
        return true;
    }

    public bool UpdateEmployee(UpdateEmployee updateEmployee)
    {
        Entities.Employee? employee = context.Employees.FirstOrDefault(x => x.IsDeleted == false && x.Id == updateEmployee.Id);
        if (employee is null) return false;
        context.Employees.Update(employee.UpdateToEmployee(updateEmployee));
        context.SaveChanges();
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        Entities.Employee? employee = context.Employees.FirstOrDefault(x => x.Id == id);
        if (employee is null) return false;
        employee.DeleteToEmployee();
        context.SaveChanges();
        return true;
    }
}
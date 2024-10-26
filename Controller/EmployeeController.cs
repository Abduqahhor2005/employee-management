using EMS.DTOs;
using EMS.Entities;
using EMS.Filter;
using EMS.Response;
using EMS.Service.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controller;

[ApiController]
[Route("api/employee")]
public class EmployeeController(IEmployeeService employeeService):ControllerBase
{
    [HttpGet]
    public IActionResult GetEmployees([FromQuery] EmployeeFilter filter)
        => Ok(ApiResponse<PaginationResponse<IEnumerable<ReadEmployee>>>.Success(null,
            employeeService.GetAllEmployees(filter)));
    [HttpGet("{id:int}")]
    public IActionResult GetEmployeeById(int id)
    {
        ReadEmployee? res = employeeService.GetEmployeeById(id);
        return res != null
            ? Ok(ApiResponse<ReadEmployee?>.Success(null, res))
            : NotFound(ApiResponse<ReadEmployee?>.Fail(null, null));
    }
    [HttpGet("{id:int} && {data}")]
    public IActionResult GetEmployeeSalary(int id, DateTime data)
    {
        EmployeeSalary? res = employeeService.GetEmployeeSalary(id,data);
        return res != null
            ? Ok(ApiResponse<EmployeeSalary?>.Success(null, res))
            : NotFound(ApiResponse<EmployeeSalary?>.Fail(null, null));
    }
    [HttpGet("employeeswithjournal")]
    public IActionResult GetEmployeeWithJournal()
    {
        IEnumerable<EmployeeWithJournal> res = employeeService.GetAllEmployeesWithJournal();
        return res != null
            ? Ok(ApiResponse<IEnumerable<EmployeeWithJournal?>>.Success(null, res))
            : NotFound(ApiResponse<EmployeeWithJournal?>.Fail(null, null));
    }
    
    [HttpGet("employeeswithjournalincurrentmonth")]
    public IActionResult GetEmployeeWithJournalInCurrentMonth()
    {
        IEnumerable<EmployeeWithJournal> res = employeeService.GetAllEmployeesWithJournalInCurrentMonth();
        return res != null
            ? Ok(ApiResponse<IEnumerable<EmployeeWithJournal?>>.Success(null, res))
            : NotFound(ApiResponse<EmployeeWithJournal?>.Fail(null, null));
    }
    
    [HttpGet("employeeswithjournalcount")]
    public IActionResult GetEmployeeWithJournalCount()
    {
        IEnumerable<EmployeeWithJournalCount> res = employeeService.GetAllEmployeesWithJournalCount();
        return res != null
            ? Ok(ApiResponse<IEnumerable<EmployeeWithJournalCount?>>.Success(null, res))
            : NotFound(ApiResponse<EmployeeWithJournalCount?>.Fail(null, null));
    }
    
    [HttpGet("employeeswithexperience")]
    public IActionResult GetEmployeeWithExperience()
    {
        IEnumerable<EmployeesWithExperience> res = employeeService.GetEmployeesWithExperience();
        return res != null
            ? Ok(ApiResponse<IEnumerable<EmployeesWithExperience?>>.Success(null, res))
            : NotFound(ApiResponse<EmployeesWithExperience?>.Fail(null, null));
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] string name,int age, string email, string phoneNumber)
    {
        CreateEmployee employee = new CreateEmployee(name, age, email,phoneNumber);
        bool res = employeeService.CreateEmployee(employee);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
    }

    [HttpPut]
    public IActionResult UpdateEmployee(UpdateEmployee employee)
    {
        bool res = employeeService.UpdateEmployee(employee);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id)
    {
        bool res = employeeService.DeleteEmployee(id);
        return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : NotFound(ApiResponse<bool>.Fail(null, res));
    }
}
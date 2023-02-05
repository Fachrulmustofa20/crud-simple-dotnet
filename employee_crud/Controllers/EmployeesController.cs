using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_crud.Models;
using employee_crud.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[ApiController]
[Route("[controller]")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _employeeService.GetEmployeeList();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var result = await _employeeService.GetEmployee(id);
        if (result == null){
            return NotFound();
        } else {
            return Ok(result);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
    {
        var result = await _employeeService.CreateEmployee(employee);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
    {
        var checkId = await _employeeService.GetEmployee(employee.Id);
        if (checkId == null){
            return NotFound();
        } else {
            var result = await _employeeService.UpdateEmployee(employee);

            return Ok(result);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var checkId = await _employeeService.GetEmployee(id);
        if (checkId == null){
            return NotFound();
        }else{
            var result = await _employeeService.DeleteEmployee(id);

            return Ok(result);
        }
    }
}
using System;
using employee_crud.Models;

namespace employee_crud.Services
{
	public interface IEmployeeService
	{
        Task<bool> CreateEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int key);
    }
}


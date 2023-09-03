using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        void AddEmployee(EmployeeDTO employeeDTO);
    }
}

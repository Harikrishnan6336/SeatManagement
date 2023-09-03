using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                Name = employeeDTO.Name,
                DepartmentId = employeeDTO.DepartmentId
            };
            _unitOfWork.Employee.Add(employee);
            _unitOfWork.Commit();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.Employee.GetAll();
        }
    }
}

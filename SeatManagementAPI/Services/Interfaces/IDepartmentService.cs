using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        void AddDepartment(DepartmentDTO departmentDTO);
    }
}

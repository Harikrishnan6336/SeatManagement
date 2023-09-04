using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        int AddDepartment(DepartmentDTO departmentDTO);
    }
}

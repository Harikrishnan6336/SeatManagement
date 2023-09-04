using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddDepartment(DepartmentDTO departmentDTO)
        {
            var department = new Department()
            {
                Name = departmentDTO.Name,
            };
            _unitOfWork.Department.Add(department);
            _unitOfWork.Commit();
            return department.Id;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _unitOfWork.Department.GetAll();
        }
    }
}

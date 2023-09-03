using SeatManagementDomain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.DTOs
{
    public class EmployeeDTO
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [ForeignKey("FK_Employee_Department_DepartmentId")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
    }
}

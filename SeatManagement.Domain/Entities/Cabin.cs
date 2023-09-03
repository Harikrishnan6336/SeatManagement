using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class Cabin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [ForeignKey("FK_Cabin_Facility_FacilityId")]
        public int FacilityId { get; set; }

        [ForeignKey("FK_Cabin_Employee_EmployeeId")]
        public int? EmployeeId { get; set; }

        public Facility Facility { get; set; } = null!;
        public Employee? Employee { get; set; }    
    }
}

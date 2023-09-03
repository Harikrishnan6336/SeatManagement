using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [ForeignKey("FK_Seat_Facility_FacilityId")]
        public int FacilityId { get; set; }

        [ForeignKey("FK_Seat_Employee_Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Facility Facility { get; set; } = null!;
    }
}

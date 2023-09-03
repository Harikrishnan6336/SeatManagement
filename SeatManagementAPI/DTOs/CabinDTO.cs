using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.DTOs
{
    public class CabinDTO
    {
        public string? Name { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}

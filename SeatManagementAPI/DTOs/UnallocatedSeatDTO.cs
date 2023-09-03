namespace SeatManagementAPI.DTOs
{
    public class UnallocatedSeatDTO
    {
        public int SeatId { get; set; }
        public string? Name { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}

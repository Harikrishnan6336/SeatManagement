namespace SeatManagementAPI.DTOs
{
    public class ReportDTO
    {
        public int SeatId;
        public string SeatName { get; set; } = null!;
        public int FacilityId { get; set; }
        public Int16 FacilityFloor { get; set; }
        public string FacilityName { get; set; }
        public int? EmployeeId { get; set; }
        public string CityName { get; set; } = null!;
        public string CityAbbreviation { get; set; } = null!;
        public string BuildingName { get; set; } = null!;
        public string BuildingAbbreviation { get; set; } = null!;
    }
}

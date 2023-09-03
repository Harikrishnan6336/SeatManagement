using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.DTOs
{
    public class FacilityDTO
    {
        public string? Name { get; set; }
        public Int16 Floor { get; set; }
        public int CityId { get; set; }
        public int BuildingId { get; set; }
    }
}


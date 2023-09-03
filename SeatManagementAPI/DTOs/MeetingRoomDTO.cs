using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.DTOs
{
    public class MeetingRoomDTO
    {
        public string Name { get; set; }
        public int FacilityId { get; set; }
        public int SeatCount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class MeetingRoom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }

        [ForeignKey("FK_MeetingRoom_Facility_FacilityId")]
        public int FacilityId { get; set; }

        public Facility Facility { get; set; } = null!; 
    }
}

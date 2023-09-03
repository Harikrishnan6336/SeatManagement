using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class Facility
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        public Int16 Floor { get; set; }

        [ForeignKey("FK_Facility_City_CityId")]
        public int CityId { get; set; }

        [ForeignKey("FK_Facility_Building_BuildingId")]
        public int BuildingId { get; set; }

        public Building Building { get; set; } = null!;

        public City City { get; set; } = null!;
    }
}

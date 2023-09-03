using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementAPI.DTOs
{
    public class FacilityViewDTO
    {
        public int FacilityId { get; set; }
        public string CityAbbreviation { get; set; }
        public string BuildingAbbreviation { get; set; }
        public Int16 FaciltyFloor { get; set; }
        public string FaciltyName { get; set; }
    }
}

using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IFacilityService
    {
        IEnumerable<Facility> GetFacilities();
        IEnumerable<FacilityViewDTO> GetFacilitiesNomenclature();
        int AddFacility(FacilityDTO facilityDTO);

    }
}

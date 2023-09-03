using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFacility(FacilityDTO facilityDTO)
        {
            var facility = new Facility()
            {
                Name = facilityDTO.Name,
                Floor = facilityDTO.Floor,
                CityId = facilityDTO.CityId,
                BuildingId = facilityDTO.BuildingId,

            };
            _unitOfWork.Facility.Add(facility);
            _unitOfWork.Commit();
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return _unitOfWork.Facility.GetAll();
        }
    }
}

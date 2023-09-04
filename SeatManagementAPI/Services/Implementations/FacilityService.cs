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

        public int AddFacility(FacilityDTO facilityDTO)
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
            return facility.Id;
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return _unitOfWork.Facility.GetAll();
        }

        public IEnumerable<FacilityViewDTO> GetFacilitiesNomenclature()
        {
            var facilityList = _unitOfWork.Facility.GetAll();
            var facilityViewDTOList = new List<FacilityViewDTO>();
            foreach (Facility facility in facilityList) 
            {
                var cityAbbreviation = _unitOfWork.City.GetById(facility.CityId).Abbreviation;
                var buildingAbbreviation = _unitOfWork.Building.GetById(facility.BuildingId).Abbreviation;
                facilityViewDTOList.Add(new FacilityViewDTO
                {
                    FacilityId = facility.Id,
                    CityAbbreviation = cityAbbreviation,
                    BuildingAbbreviation = buildingAbbreviation,
                    FaciltyFloor = facility.Floor,
                    FaciltyName = facility.Name
                }) ; 
            }
            return facilityViewDTOList;

        }
    }
}

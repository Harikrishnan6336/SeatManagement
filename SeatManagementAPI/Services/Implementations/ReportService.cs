using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.Services.Interfaces;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ReportDTO> Get()
        {
            var reportDTOlist = new List<ReportDTO>();
            var seatList = _unitOfWork.Seat.GetAll().Where(s => s.EmployeeId == null);
            var cityList = _unitOfWork.City.GetAll();
            var buildingList = _unitOfWork.Building.GetAll();
            var facilityList = _unitOfWork.Facility.GetAll();
            int SeatId, FacilityId;
            Int16 FacilityFloor;
            int? EmployeeId;

            string SeatName, CityName, CityAbbreviation, BuildingName, BuildingAbbreviation, FacilityName;
            foreach ( var seat in seatList )
            {
                SeatId = seat.Id;
                SeatName = seat.Name;
                EmployeeId = seat.EmployeeId;
                
                var facility = facilityList.FirstOrDefault(f => f.Id == seat.FacilityId);
                FacilityId = facility.Id;
                FacilityFloor = facility.Floor;
                City? city = cityList.FirstOrDefault(c => c.Id == facility.CityId);
                CityName = city.Name;
                CityAbbreviation = city.Abbreviation;
                Building? building = buildingList.FirstOrDefault(b => b.Id == facility.BuildingId);
                BuildingName = building.Name;
                BuildingAbbreviation = building.Abbreviation;
                FacilityName = facility.Name;

                ReportDTO obj = new ReportDTO()
                {
                    SeatId = SeatId, 
                    SeatName = SeatName, 
                    EmployeeId = EmployeeId, 
                    FacilityId = FacilityId,
                    CityName = CityName, 
                    CityAbbreviation = CityAbbreviation,
                    BuildingName = BuildingName,
                    BuildingAbbreviation = BuildingAbbreviation,
                    FacilityFloor = FacilityFloor,
                    FacilityName = FacilityName,
                };
                reportDTOlist.Add(obj);
            }
            return reportDTOlist;
        }
    }
}
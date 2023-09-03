using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Building> GetBuildings()
        {
            return _unitOfWork.Building.GetAll();
        }

        public void AddBuilding(BuildingDTO buildingDTO)
        {
            var building = new Building()
            {
                Name = buildingDTO.Name,
                Abbreviation = buildingDTO.Abbreviation
            };
            _unitOfWork.Building.Add(building);
            _unitOfWork.Commit();
        }

    }
}

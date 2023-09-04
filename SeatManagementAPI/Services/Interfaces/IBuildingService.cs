using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetBuildings();

        int AddBuilding(BuildingDTO building);
    }
}





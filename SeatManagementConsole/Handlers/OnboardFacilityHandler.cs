using SeatManagementDomain.Entities;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementConsole.Managers;
using SeatManagement.Menus;
using SeatManagementConsole.Handlers;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityHandler
    {
        private readonly IEntityManager<City> _cityManager;
        private readonly IEntityManager<Building> _buildingManager;
        private readonly IEntityManager<Facility> _facilityManager;

        private readonly OnboardFacilityCityHandler _facilityCityHandler;
        private readonly OnboardFacilityBuildingHandler _facilityBuildingHandler;

        public OnboardFacilityHandler(IEntityManager<City> cityManager, 
                                      IEntityManager<Building> buildingManager, 
                                      IEntityManager<Facility> facilityManager)
        {
            _cityManager = cityManager;
            _buildingManager = buildingManager;
            _facilityManager = facilityManager;

            _facilityCityHandler = new OnboardFacilityCityHandler(_cityManager);
            _facilityBuildingHandler = new OnboardFacilityBuildingHandler(_buildingManager);
        }
        public void Handle()
        {

            var cityId = _facilityCityHandler.Handle();

            var buildingId = _facilityBuildingHandler.Handle();

            Console.Write("Enter the facility name: ");
            var facilityName = Console.ReadLine();
            Console.Write("Enter the facility floor: ");
            var facilityFloor = Convert.ToInt16(Console.ReadLine());

            var facilityObj = new Facility
            {
                Name = facilityName,
                Floor = facilityFloor,
                CityId = cityId,
                BuildingId = buildingId
            };

            _facilityManager.Add(facilityObj);
            Console.WriteLine("Your facility has been added successfully");

        }
    }
}

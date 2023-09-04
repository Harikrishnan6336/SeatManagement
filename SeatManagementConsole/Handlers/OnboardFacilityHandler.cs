using SeatManagementDomain.Entities;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementConsole.IOInterfaces;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityHandler : IHandler
    {
        private readonly IEntityManager<City> _cityManager;
        private readonly IEntityManager<Building> _buildingManager;
        private readonly IEntityManager<Facility> _facilityManager;
        private readonly IUserInputHandler _userInputHandler;

        private readonly OnboardFacilityCityHandler _facilityCityHandler;
        private readonly OnboardFacilityBuildingHandler _facilityBuildingHandler;

        public OnboardFacilityHandler(IEntityManager<City> cityManager,
                                      IEntityManager<Building> buildingManager, 
                                      IEntityManager<Facility> facilityManager,
                                      IUserInputHandler userInputHandler)
        {
            _cityManager = cityManager;
            _buildingManager = buildingManager;
            _facilityManager = facilityManager;
            _userInputHandler = userInputHandler;
            _facilityCityHandler = new OnboardFacilityCityHandler(_cityManager, _userInputHandler);
            _facilityBuildingHandler = new OnboardFacilityBuildingHandler(_buildingManager, _userInputHandler);
        }
        public int Handle()
        {
            var cityId = _facilityCityHandler.Handle();
            var buildingId = _facilityBuildingHandler.Handle();
            if(cityId == -1 || buildingId == -1) 
            {
                return 0;
            }

            var facilityName = _userInputHandler.GetUserInputString("Enter the facility name: ");

            Console.Write("Enter the Floor number: ");
            var facilityFloor = Convert.ToInt16(Console.ReadLine());
            while(facilityFloor > -1 && facilityFloor < 100) 
            {
                Console.WriteLine("Invalid Floor number. (-1< num< 100)");
                Console.Write("Try Again. Enter the Floor number:  ");
                facilityFloor = Convert.ToInt16(Console.ReadLine());
            }

            var facilityObj = new Facility
            {
                Name = facilityName,
                Floor = facilityFloor,
                CityId = cityId,
                BuildingId = buildingId
            };

            _facilityManager.Add(facilityObj);
            Console.WriteLine("Your facility has been added successfully");
            return 0;
        }
    }
}

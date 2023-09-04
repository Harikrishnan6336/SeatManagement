using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using System.Text.RegularExpressions;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityBuildingHandler : IHandler
    {
        private readonly IEntityManager<Building> _buildingManager;
        private readonly IUserInputHandler _userInputHandler;

        public OnboardFacilityBuildingHandler(IEntityManager<Building> buildingManager, IUserInputHandler userInputHandler)
        {
            _buildingManager = buildingManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
        {
            Console.WriteLine("[1].Add to existing building\n[2].Add new building\n[3].Cancel Onboard Facility");
            Console.Write("Enter your option: ");

            char buildingMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (buildingMenuOption)
            {
                case '1':
                    return AddToExistingBuilding();
                case '2':
                    return AddToNewBuilding();
                case '3':
                    Console.WriteLine("Onboard of Facility Cancelled.");
                    return -1;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    return Handle();
            }
        }

        private int AddToExistingBuilding()
        {
            var buildingList = _buildingManager.Get();
            DisplayList.DisplayEntityList<Building>(buildingList);
            int buildingId;
            bool isValidId = false;

            while(!isValidId)
            {
                buildingId = _userInputHandler.GetUserInputInt("nter the building id of the building you want: ");
                if (buildingList.Any(building => building.Id == buildingId))
                {
                    return buildingId;
                }
                else
                {
                    Console.WriteLine("Invalid building id. Please try again.");
                }
            }
            return -1;
        }

        private int AddToNewBuilding()
        {
            var buildingName = _userInputHandler.GetUserInputString("Enter the name of the building: ");
            var buildingAbbrv = _userInputHandler.GetUserInputString("Enter the building abbreviation: ");

            while (!Regex.Match(buildingAbbrv, "^[A-Z]{3}$").Success)
            {
                Console.WriteLine("Invalid Abbreviation. Abbreviations should be of the form [XXX]. Try Again. ");
                buildingAbbrv = _userInputHandler.GetUserInputString("Enter the building abbreviation: ");
            }

            var buildingObj = new Building
            {
                Name = buildingName,
                Abbreviation = buildingAbbrv
            };

            return _buildingManager.Add(buildingObj);
        }
    }
}
using SeatManagement.Interfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityBuildingHandler
    {
        private readonly IEntityManager<Building> _buildingManager;

        public OnboardFacilityBuildingHandler(IEntityManager<Building> buildingManager)
        {
            _buildingManager = buildingManager;
        }

        public int Handle()
        {
            Console.WriteLine("[1].Add to existing building\n[2].Add new building");
            Console.Write("Enter your option: ");

            char buildingMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (buildingMenuOption)
            {
                case '1':
                    return AddToExistingBuilding();
                case '2':
                    return AddToNewBuilding();
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    return Handle();
            }
        }

        private int AddToExistingBuilding()
        {
            var buildingList = _buildingManager.Get();
            foreach (var building in buildingList)
            {
                Console.WriteLine($"{building.Id}. {building.Name}");
            }

            Console.Write("Enter the building id of the building you want: ");
            var buildingId = Convert.ToInt32(Console.ReadLine());

            if (buildingList.Any(building => building.Id == buildingId))
            {
                return buildingId;
            }
            else
            {
                Console.WriteLine("Invalid building id. Please try again.");
                return AddToExistingBuilding();
            }
        }

        private int AddToNewBuilding()
        {
            Console.Write("Enter the name of the building: ");
            var buildingName = Console.ReadLine();
            Console.Write("Enter the building abbreviation: ");
            var buildingAbbrv = Console.ReadLine();

            var buildingObj = new Building
            {
                Name = buildingName,
                Abbreviation = buildingAbbrv
            };

            return _buildingManager.Add(buildingObj);
        }
    }
}




using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityCityHandler : IHandler
    {
        private readonly IEntityManager<City> _cityManager;
        private readonly IUserInputHandler _userInputHandler;

        public OnboardFacilityCityHandler(IEntityManager<City> cityManager, IUserInputHandler userInputHandler)
        {
            _cityManager = cityManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
        {
            Console.WriteLine("[1].Add to existing city\n[2].Add to new city");
            Console.Write("Enter your option:");

            char cityMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (cityMenuOption)
            {
                case '1':
                    return AddToExistingCity();
                    
                case '2':
                    return AddToNewCity();
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    return Handle();
            }
        }

        private int AddToExistingCity()
        {
            var cityList = _cityManager.Get();
            DisplayList.DisplayEntityList<City>(cityList);
            var cityId = _userInputHandler.GetUserInputInt("Enter the city id of the city you want: ");

            if (cityList.Any(city => city.Id == cityId))
            {
                return cityId;
            }
            else
            {
                Console.WriteLine("Invalid city id. Please try again.");
                return AddToExistingCity();
            }
        }

        private int AddToNewCity()
        {
            var cityName = _userInputHandler.GetUserInputString("Enter the name of the city: ");
            var cityAbbrv = _userInputHandler.GetUserInputString("Enter the city abbreviation: ");

            var cityObj = new City
            {
                Name = cityName,
                Abbreviation = cityAbbrv
            };

            return _cityManager.Add(cityObj);
        }
    }
}

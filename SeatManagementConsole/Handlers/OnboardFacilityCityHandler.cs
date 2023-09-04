using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using System.Text.RegularExpressions;

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
            Console.WriteLine("[1].Add to existing city\t\t[2].Add to new city\n[3].Cancel Onboard Facility");
            Console.Write("Enter your option:");

            char cityMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (cityMenuOption)
            {
                case '1':
                    return AddToExistingCity();
                    
                case '2':
                    return AddToNewCity();
                case '3':
                    Console.WriteLine("Onboard of Facility Cancelled.");
                    return -1;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    return Handle();
            }
        }

        private int AddToExistingCity()
        {
            var cityList = _cityManager.Get();
            DisplayList.DisplayEntityList<City>(cityList);
            int cityId;
            bool isValidId = false;

            while (!isValidId)
            {
                cityId = _userInputHandler.GetUserInputInt("Enter the city id of the city you want: ");

                if (cityList.Any(city => city.Id == cityId))
                {
                    return cityId;
                }
                else
                {
                    Console.WriteLine("Invalid city id. Please try again.");
                }
            }
            return -1;
        }

        private int AddToNewCity()
        {
            var cityName = _userInputHandler.GetUserInputString("Enter the name of the city: ");
            string cityAbbrv = _userInputHandler.GetUserInputString("Enter the city abbreviation: ");

            while (!Regex.Match(cityAbbrv, "^[A-Z]{3}$").Success)
            {
                Console.WriteLine("Invalid Abbreviation. Abbreviations should be of the form [XXX]. Try Again. ");
                cityAbbrv = _userInputHandler.GetUserInputString("Enter the city abbreviation: ");
            }

            var cityObj = new City
            {
                Name = cityName,
                Abbreviation = cityAbbrv
            };
            int kk = _cityManager.Add(cityObj);
            Console.WriteLine(kk);
            return kk;
        }
    }
}

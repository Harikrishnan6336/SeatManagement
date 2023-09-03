using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardFacilityCityHandler
    {
        private readonly IEntityManager<City> _cityManager;

        public OnboardFacilityCityHandler(IEntityManager<City> cityManager)
        {
            _cityManager = cityManager;
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
            foreach (var city in cityList)
            {
                Console.WriteLine($"{city.Id}. {city.Name}");
            }

            Console.Write("Enter the city id of the city you want: ");
            var cityId = Convert.ToInt32(Console.ReadLine());

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
            Console.Write("Enter the name of the city: ");
            var cityName = Console.ReadLine();
            Console.Write("Enter the city abbreviation: ");
            var cityAbbrv = Console.ReadLine();

            var cityObj = new City
            {
                Name = cityName,
                Abbreviation = cityAbbrv
            };

            return _cityManager.Add(cityObj);
        }
    }
}

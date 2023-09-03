using SeatManagementConsole.ManagerInterfaces;
using SeatManagementConsole.Managers;
using SeatManagementConsole.Handlers;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole
{
    public class Program
    {
        public static void Main()
        {

            IEntityManager<City> cityManager = new EntityManager<City>("api/cities");
            IEntityManager<Building> buildingManager = new EntityManager<Building>("api/buildings");
            IFacilityManager facilityManager = new FacilityManager("api/facilities");
            IEntityManager<Seat> seatManager = new EntityManager<Seat>("api/seats");


            Console.WriteLine("----------------------SEAT ALLOCATION MANAGER-------------------------");
            Console.WriteLine("MENU");
            Console.WriteLine("[1].Onboard Facility\n[2].Onboard Seats\n[3].Onboard Meeting Rooms\n[4].Onboard Cabins\n[5].Add Employees\n[6].Seat Allocation\n[7].Seat Deallocation\n[8].Report Generation");
            Console.Write("Choose your option: ");

            char mainMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Clear();
            switch (mainMenuOption)
            {

                case '1':
                    OnboardFacilityHandler onboardFacilityhandler = new(cityManager, buildingManager, facilityManager);
                    onboardFacilityhandler.Handle();
                    break;
                case '2':
                    OnboardSeatHandler onboardSeathandler = new(facilityManager, seatManager);
                    onboardSeathandler.Handle();
                    break;

            }
        }
    }
}
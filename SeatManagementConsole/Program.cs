using SeatManagementConsole.ManagerInterfaces;
using SeatManagementConsole.Managers;
using SeatManagementConsole.Handlers;
using SeatManagementDomain.Entities;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.IOImplementations;

namespace SeatManagementConsole
{
    public class Program
    {
        public static void Main()
        {
            IFacilityManager facilityManager = new FacilityManager("api/facilities");
            ISeatManager seatManager = new SeatManager("api/seats");

            ISeatManager<City> cityManager = new EntityManager<City>("api/cities");
            ISeatManager<Building> buildingManager = new EntityManager<Building>("api/buildings");
            
            ISeatManager<MeetingRoom> meetingRoomManager = new EntityManager<MeetingRoom>("api/meetingrooms");
            ISeatManager<Cabin> cabinManager = new EntityManager<Cabin>("api/cabins");



            IUserInputHandler consoleUserInputHandler = new ConsoleUserInputHandler();


            Console.WriteLine("----------------------SEAT ALLOCATION MANAGER-------------------------");
            Console.WriteLine("MENU");
            Console.WriteLine("[1].Onboard Facility\n[2].Add Seats\n[3].Add Meeting Rooms\n[4].Add Cabins\n[5].Add Employees\n[6].Seat Allocation\n[7].Seat Deallocation\n[8].Report Generation");
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
                    OnboardSeatHandler onboardSeathandler = new(facilityManager, seatManager, consoleUserInputHandler);
                    onboardSeathandler.Handle();
                    break;
                case '3':
                    OnboardMeetingRoomHandler onboardMeetingRoomHandler = new(facilityManager, meetingRoomManager, consoleUserInputHandler);
                    onboardMeetingRoomHandler.Handle();
                    break;
                case '4':
                     OnboardCabinHandler onboardCabinHandler = new(facilityManager, cabinManager, consoleUserInputHandler);
                    onboardCabinHandler.Handle();
                    break;
                case '5':
                    // TODO
                    break;
                case '6':
                    SeatAllocationHandler seatAllocationHandler = new(facilityManager, seatManager, consoleUserInputHandler);
                    seatAllocationHandler.Handle();
                    break;
            }
        }
    }
}
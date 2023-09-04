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
            ICabinManager cabinManager = new CabinManager("api/cabins");
            IReportManager reportManager = new ReportManager("api/reports");

            IEntityManager<City> cityManager = new EntityManager<City>("api/cities");
            IEntityManager<Building> buildingManager = new EntityManager<Building>("api/buildings");
            IEntityManager<Employee> employeeManager = new EntityManager<Employee>("api/employees");
            IEntityManager<MeetingRoom> meetingRoomManager = new EntityManager<MeetingRoom>("api/meetingrooms");


            IUserInputHandler consoleUserInputHandler = new ConsoleUserInputHandler();
            char mainMenuOption;
            do
            {
                Console.WriteLine("----------------------SEAT ALLOCATION MANAGER-------------------------");
                Console.WriteLine("MENU");
                Console.WriteLine("[1].Onboard Facility\t\t[2].Add Seats\n[3].Add Meeting Rooms\t\t[4].Add Cabins\n[5].Add Employees List via CSV\t\t[6].Seat Allocation\n[7].Cabin Allocation\t\t[8].Report Generation\n[9].EXIT\n");
                Console.Write("Choose your option: ");

                mainMenuOption = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.Clear();
                switch (mainMenuOption)
                {
                    case '1':
                        OnboardFacilityHandler onboardFacilityhandler = new(cityManager, buildingManager, facilityManager, consoleUserInputHandler);
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
                        AddEmployeesCSVHandler addEmployeesCSVHandler = new(employeeManager, consoleUserInputHandler);
                        addEmployeesCSVHandler.Handle();
                        break;
                    case '6':
                        SeatAllocationHandler seatAllocationHandler = new(facilityManager, seatManager, employeeManager,consoleUserInputHandler);
                        seatAllocationHandler.Handle();
                        break;
                    case '7':
                       CabinAllocationHandler cabinAllocationHandler = new(facilityManager, cabinManager, employeeManager, consoleUserInputHandler);
                        cabinAllocationHandler.Handle();

                        break;
                    case '8':
                        ReportHandler reportHandler = new(cityManager, buildingManager, facilityManager, seatManager, reportManager,consoleUserInputHandler);
                        reportHandler.Handle();
                        break;
                    case '9':
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Oops! Invalid choice. Please try again.");
                        break;

                }

            } while (mainMenuOption != '9');


        }
    }
}
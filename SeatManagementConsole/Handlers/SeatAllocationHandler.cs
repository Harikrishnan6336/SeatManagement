using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class SeatAllocationHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ISeatManager _seatManager;
        private readonly IUserInputHandler _userInputHandler;
        private readonly IEntityManager<Employee> _employeeManager;

        public SeatAllocationHandler(IFacilityManager facilityManager,
                                  ISeatManager seatManager,
                                  IEntityManager<Employee> employeeManager,
                                  IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _seatManager = seatManager;
            _employeeManager = employeeManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
        {

            var facilityViewDTOList = _facilityManager.GetNomenclature();
            FacilityViewDTO temp = null;

            var employeeList = _employeeManager.Get();

            Console.WriteLine("Employee List:");
            DisplayList.DisplayEntityList<Employee>(employeeList);

            int employeeId = _userInputHandler.GetUserInputInt("Enter the employeeId who is to be allocated with a Seat: ");
            Console.WriteLine("Facility List:");
            foreach (FacilityViewDTO facilityViewDTO in facilityViewDTOList)
            {
                Console.WriteLine($"{facilityViewDTO.FacilityId}. {facilityViewDTO.CityAbbreviation}-{facilityViewDTO.BuildingAbbreviation}-{facilityViewDTO.FaciltyFloor}-{facilityViewDTO.FaciltyName}");
            }

            int facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where employee is to be allocated):");
 
            foreach (FacilityViewDTO facilityViewDTO in facilityViewDTOList)
            {
                if (facilityViewDTO.FacilityId == facilityId)
                {
                    temp = facilityViewDTO;
                    break; 
                }
            }

            var unallocatedSeatsList = _seatManager.GetUnoccupiedSeatsByFacility(facilityId);
            if (!unallocatedSeatsList.Any())
            {
                Console.WriteLine("Unoccupied seats are not available.\n");
                return 0;
            }

            foreach (Seat unallocatedSeat in unallocatedSeatsList)
            {
                Console.WriteLine($"{unallocatedSeat.Id}. {temp.CityAbbreviation}-{temp.BuildingAbbreviation}-{temp.FaciltyFloor}-{temp.FaciltyName}-{unallocatedSeat.Name}");
            }
            int seatId = _userInputHandler.GetUserInputInt("Choose the Seat(where employee is to be allocated):");

            _seatManager.SeatAllocate(new SeatAllocateDTO()
            {
                SeatId = seatId,
                EmployeeId = employeeId
            });

            Console.WriteLine("Your seats has been allocated successfully");
            _userInputHandler.WaitForUserInput();
            return 0;
        }
    }
}

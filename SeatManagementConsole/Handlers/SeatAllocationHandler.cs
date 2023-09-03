using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class SeatAllocationHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ISeatManager _seatManager;
        private readonly IUserInputHandler _userInputHandler;

        public SeatAllocationHandler(IFacilityManager facilityManager,
                                  ISeatManager seatManager,
                                  IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _seatManager = seatManager;
            _userInputHandler = userInputHandler;
        }

        public void Handle()
        {
            Console.WriteLine("Facility List:");
            var facilityViewDTOList = _facilityManager.GetNomenclature();
            FacilityViewDTO temp = null;

            // TODO

            int employeeId = _userInputHandler.GetUserInputInt("Enter the employeeId who is to be Seat allocated: ");

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


        }
    }
}

using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardSeatHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly IEntityManager<Seat> _seatManager;
        private readonly IUserInputHandler _userInputHandler;

        public OnboardSeatHandler(IFacilityManager facilityManager,
                                  IEntityManager<Seat> seatManager,
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
            foreach (FacilityViewDTO facilityViewDTO in facilityViewDTOList)
            {
                Console.WriteLine($"{facilityViewDTO.FacilityId}. {facilityViewDTO.CityAbbreviation}-{facilityViewDTO.BuildingAbbreviation}-{facilityViewDTO.FaciltyFloor}-{facilityViewDTO.FaciltyName}");
            }

            var facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where seats should be added):");
            var noOfSeats = _userInputHandler.GetUserInputInt("Enter the number of seats to add:");

            var seatListCount = _seatManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            int seatCount = seatListCount + 1;
            // TODO Allow an Employee to be allocated here itself.
            for (int i = 0; i < noOfSeats; i++)
            {
                var seatName = "S" + seatCount;
                seatCount++;
                var seat = new Seat
                {
                    FacilityId = facilityId,
                    Name = seatName,
                    EmployeeId = null
                };
                _seatManager.Add(seat);
            }
            Console.WriteLine("Your seats has been added successfully");
            _userInputHandler.WaitForUserInput();

        }
    }
}

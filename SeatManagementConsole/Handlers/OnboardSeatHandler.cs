using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardSeatHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ISeatManager _seatManager;
        private readonly IUserInputHandler _userInputHandler;

        public OnboardSeatHandler(IFacilityManager facilityManager, ISeatManager seatManager, IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _seatManager = seatManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
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

            AddSeats(facilityId, noOfSeats, seatCount);

            Console.WriteLine("Your seats has been added successfully");
            _userInputHandler.WaitForUserInput();
            return 0;
        }

        private void AddSeats(int facilityId, int noOfSeats, int seatCount)
        {
            for (int i = 0; i < noOfSeats; i++)
            {
                var seatName = GenerateSeatName(seatCount);
                seatCount++;
                var seat = new Seat
                {
                    FacilityId = facilityId,
                    Name = seatName,
                    EmployeeId = null
                };
                _seatManager.Add(seat);
            }
        }

        private static string GenerateSeatName(int seatCount)
        {
            return "S" + seatCount.ToString("D3");
        }
    }
}

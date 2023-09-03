using SeatManagementAPI.DTOs;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardSeatHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly IEntityManager<Seat> _seatManager;

        public OnboardSeatHandler(IFacilityManager facilityManager,
                                  IEntityManager<Seat> seatManager)
        {
            _facilityManager = facilityManager;
            _seatManager = seatManager;
        }

        public int Handle()
        {
            Console.WriteLine("Facility List:");
            var facilityViewDTOList = _facilityManager.GetNomenclature();
            foreach (FacilityViewDTO facilityViewDTO in facilityViewDTOList)
            {
                Console.WriteLine($"{facilityViewDTO.FacilityId}. {facilityViewDTO.CityAbbreviation}-{facilityViewDTO.BuildingAbbreviation}-{facilityViewDTO.FaciltyFloor}-{facilityViewDTO.FaciltyName}");
            }
            Console.WriteLine("Choose the facility id:");
            var facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of seats to add:");
            var noOfSeats = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return 0;
        }
    }
}

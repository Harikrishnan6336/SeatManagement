using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardCabinHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ICabinManager _cabinManager;
        private readonly IUserInputHandler _userInputHandler;
        public OnboardCabinHandler(IFacilityManager facilityManager, ICabinManager cabinManager,
                                         IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _cabinManager = cabinManager;
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

            var facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where cabin should be added):");

            var cabinListCount = _cabinManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            cabinListCount++;
            var cabinName = GenerateCabinName(cabinListCount);

            var cabin = new Cabin
            {
                FacilityId = facilityId,
                Name = cabinName,
                EmployeeId = null
            };
            _cabinManager.Add(cabin);
            Console.WriteLine("Your cabin has been added successfully");
            _userInputHandler.WaitForUserInput();
            return 0;
        }

        private static string GenerateCabinName(int cabinListCount)
        {
            return "C" + cabinListCount.ToString("D3");
        }


    }
}

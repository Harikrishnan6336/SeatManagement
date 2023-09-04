using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using SeatManagementConsole.IOImplementations;
using SeatManagementAPI.DTOs;

namespace SeatManagementConsole.Handlers
{
    public class CabinAllocationHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ICabinManager _cabinManager;
        private readonly IUserInputHandler _userInputHandler;
        private readonly IEntityManager<Employee> _employeeManager;

        public CabinAllocationHandler(IFacilityManager facilityManager,
                                  ICabinManager cabinManager,
                                  IEntityManager<Employee> employeeManager,
                                  IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _cabinManager = cabinManager;
            _employeeManager = employeeManager;
            _userInputHandler = userInputHandler;
        }
        public int Handle()
        {
            var facilityViewDTOList = _facilityManager.GetNomenclature();
            FacilityViewDTO temp = null;

            var unallocatedCabinsList = _cabinManager.GetUnoccupiedCabins();
            if(!unallocatedCabinsList.Any()) 
            {
                Console.WriteLine("Unoccupied cabins are not available.\n");
                return 0; 
            }

            var employeeList = _employeeManager.Get();
            Console.WriteLine("Available Cabins: ");

            foreach ( var cabin in unallocatedCabinsList)
            {
                var facility = facilityViewDTOList.FirstOrDefault(f => f.FacilityId == cabin.FacilityId);
                Console.WriteLine($"{cabin.Id}. {facility.CityAbbreviation}-{facility.BuildingAbbreviation}-{facility.FaciltyFloor}-{facility.FaciltyName}-{cabin.Name}");
            }
            int cabinId = _userInputHandler.GetUserInputInt("Choose the Cabin(where employee is to be allocated):");

            Console.WriteLine("Employee List:");
            DisplayList.DisplayEntityList<Employee>(employeeList);
            int employeeId = _userInputHandler.GetUserInputInt("Enter the employeeId who is to be allocated with a Cabin: ");


            _cabinManager.CabinAllocate(new CabinAllocateDTO()
            {
                CabinId = cabinId,
                EmployeeId = employeeId
            });

            Console.WriteLine("Your seats has been allocated successfully");
            _userInputHandler.WaitForUserInput();
            return 0;
        }
    }
}

using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Handlers
{
    public class OnboardCabinHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly IEntityManager<Cabin> _cabinManager;
        private readonly IUserInputHandler _userInputHandler;
        public OnboardCabinHandler(IFacilityManager facilityManager,
                                         IEntityManager<Cabin> cabinManager,
                                         IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _cabinManager = cabinManager;
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

            var facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where cabin should be added):");

            var cabinListCount = _cabinManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            cabinListCount++;
            var cabinName = "C" + cabinListCount;


            var cabin = new Cabin
            {
                FacilityId = facilityId,
                Name = cabinName,
                EmployeeId = null
            };
            _cabinManager.Add(cabin);
            Console.WriteLine("Your cabin has been added successfully");
            _userInputHandler.WaitForUserInput();
        }
    }
}

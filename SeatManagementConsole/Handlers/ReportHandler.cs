using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using System.Security.Principal;

namespace SeatManagementConsole.Handlers
{
    public class ReportHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly ISeatManager _seatManager;
        private readonly IReportManager _reportManager;
        private readonly IUserInputHandler _userInputHandler;
        private readonly IEntityManager<City> _cityManager;
        private readonly IEntityManager<Building> _buildingManager;

        public ReportHandler(IEntityManager<City> cityManager, IEntityManager<Building> buildingManager,
                             IFacilityManager facilityManager, ISeatManager seatManager,
                             IReportManager reportManager, IUserInputHandler userInputHandler)
        {
            _cityManager = cityManager;
            _buildingManager = buildingManager;
            _facilityManager = facilityManager;
            _seatManager = seatManager;
            _reportManager = reportManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
        {
            Console.WriteLine("Report On Free Seats\n----------------------------------------\n\n");
            var facilityViewDTOList = _facilityManager.GetNomenclature();
            var unallocatedSeatsList = _seatManager.GetUnoccupiedSeats();
            var unallocatedSeatsDetailsList = _reportManager.GenerateReport();
            int i = 1;

            foreach(ReportDTO reportDTO in unallocatedSeatsDetailsList) 
            {
                Console.WriteLine($"[{i}]. {reportDTO.CityAbbreviation}-{reportDTO.BuildingAbbreviation}-{reportDTO.FacilityFloor}-{reportDTO.FacilityName}-{reportDTO.SeatName}");
                i++;
            }
            i = 1;

            char filterReportMenuOption = '5';
            do
            {
                Console.WriteLine("To Filter Report");
                Console.WriteLine("[1]. By City \t\t[2]. By Building\n[3]. By Facility\t\t[4]. By Floor\n[5]. EXIT\n");
                Console.Write("Enter your choice: ");
                filterReportMenuOption = Console.ReadKey().KeyChar;
                Console.WriteLine("");

                switch (filterReportMenuOption)
                {
                    case '1':
                        string cityAbbreviation = GetCityAbbreviation();
                        i = 1;

                        var filteredReports = unallocatedSeatsDetailsList.Where(reportDTO => reportDTO.CityAbbreviation == cityAbbreviation);
                        Console.WriteLine($"Free Seats in {cityAbbreviation}");
                        foreach (var reportDTO in filteredReports)
                        {
                            Console.WriteLine($"[{i}]. {reportDTO.CityAbbreviation}-{reportDTO.BuildingAbbreviation}-{reportDTO.FacilityFloor}-{reportDTO.FacilityName}-{reportDTO.SeatName}");
                            i++;
                        }

                        break;
                    case '2':
                        {
                            string buildingAbbreviation = GetBuildingAbbreviation();
                            i = 1;

                            filteredReports = unallocatedSeatsDetailsList.Where(reportDTO => reportDTO.BuildingAbbreviation == buildingAbbreviation);
                            Console.WriteLine($"Free Seats in {buildingAbbreviation}");
                            foreach (var reportDTO in filteredReports)
                            {
                                Console.WriteLine($"[{i}]. {reportDTO.CityAbbreviation}-{reportDTO.BuildingAbbreviation}-{reportDTO.FacilityFloor}-{reportDTO.FacilityName}-{reportDTO.SeatName}");
                                i++;
                            }
                        }
                        break;


                    case '3':
                        {
                            var facilityList = _facilityManager.Get();
                            foreach (var facility in facilityList)
                            {
                                Console.WriteLine($"{facility.Id}. {facility.Name}");
                            }
                            var facilityId = _userInputHandler.GetUserInputInt("Enter the facility id of the facility you want: ");

                            filteredReports = unallocatedSeatsDetailsList.Where(reportDTO => reportDTO.FacilityId == facilityId);
                            Console.WriteLine($"Free Seats in the given Facility");
                            i = 1;
                            foreach (var reportDTO in filteredReports)
                            {
                                Console.WriteLine($"[{i}]. {reportDTO.CityAbbreviation}-{reportDTO.BuildingAbbreviation}-{reportDTO.FacilityFloor}-{reportDTO.FacilityName}-{reportDTO.SeatName}");
                                i++;
                            }
                        }
                        break;

                    case '4':
                        {
                            var facilityList = _facilityManager.Get();
                            var floorNumber = _userInputHandler.GetUserInputInt("Enter the Floor number you want: ");

                            filteredReports = unallocatedSeatsDetailsList.Where(reportDTO => reportDTO.FacilityFloor == floorNumber);
                            Console.WriteLine($"Free Seats in a Floor {floorNumber}");
                            i = 1;
                            foreach (var reportDTO in filteredReports)
                            {
                                Console.WriteLine($"[{i}]. {reportDTO.CityAbbreviation}-{reportDTO.BuildingAbbreviation}-{reportDTO.FacilityFloor}-{reportDTO.FacilityName}-{reportDTO.SeatName}");
                                i++;
                            }
                        }
                        break;

                    case '5':
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Oops! Invalid choice. Please try again.");
                        break;
                }
            } while (filterReportMenuOption != '5');

            Console.WriteLine("Report generated successfully");
            _userInputHandler.WaitForUserInput();
            return 0;
        }


        private string GetCityAbbreviation()
        {
            var cityList = _cityManager.Get();
            DisplayList.DisplayEntityList<City>(cityList);

            var cityId = _userInputHandler.GetUserInputInt("Enter the city id of the city you want: ");

            var cityObj = cityList.FirstOrDefault(c => c.Id == cityId);
            if (cityObj != null)
            {
                return cityObj.Abbreviation;
            }
            else
            {
                Console.WriteLine("Invalid city id. Please try again.");
                return GetCityAbbreviation();
            }
        }



        private string GetBuildingAbbreviation()
        {
            var buildingList = _buildingManager.Get();
            DisplayList.DisplayEntityList<Building>(buildingList);

            var buildingId = _userInputHandler.GetUserInputInt("Enter the building id of the building you want: ");

            var buildingObj = buildingList.FirstOrDefault(c => c.Id == buildingId);

            if (buildingObj != null)
            {
                return buildingObj.Abbreviation;
            }
            else
            {
                Console.WriteLine("Invalid building id. Please try again.");
                return GetBuildingAbbreviation();
            }
        }
    }
}

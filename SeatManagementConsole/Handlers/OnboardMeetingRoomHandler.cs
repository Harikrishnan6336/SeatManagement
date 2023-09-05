using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOImplementations;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardMeetingRoomHandler : IHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly IEntityManager<MeetingRoom> _meetingRoomManager;
        private readonly IEntityManager<Asset> _assetManager;
        private readonly IUserInputHandler _userInputHandler;
        private readonly IEntityManager<MeetingRoomAsset> _meetingRoomAssetManager;
        public OnboardMeetingRoomHandler(IFacilityManager facilityManager, IEntityManager<MeetingRoom> meetingRoomManager,
                                         IEntityManager<Asset> assetManager, IEntityManager<MeetingRoomAsset> meetingRoomAssetManager,
                                         IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _meetingRoomManager = meetingRoomManager;
            _assetManager = assetManager;
            _userInputHandler = userInputHandler;
            _meetingRoomAssetManager = meetingRoomAssetManager;
        }

        public int Handle()
        {
            Console.WriteLine("Facility List:");
            var facilityViewDTOList = _facilityManager.GetNomenclature();
            facilityViewDTOList.ForEach(facilityViewDTO => Console.WriteLine($"{facilityViewDTO.FacilityId}. {facilityViewDTO.CityAbbreviation}-{facilityViewDTO.BuildingAbbreviation}-{facilityViewDTO.FaciltyFloor}-{facilityViewDTO.FaciltyName}"));

            var facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where meeting room should be added):");
            var seatCount = _userInputHandler.GetUserInputInt("Enter the number of seats in the room");

            var meetingRoomListCount = _meetingRoomManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            meetingRoomListCount++;
            var meetingRoomName = GenerateMeetingRoomName(meetingRoomListCount);

            var meetingRoom = new MeetingRoom
            {
                FacilityId = facilityId,
                Name = meetingRoomName,
                SeatCount = seatCount,
            };
            int meetingRoomId = _meetingRoomManager.Add(meetingRoom);
            Console.WriteLine("Your meeting room has been added successfully\n");

            int assetChoice;
            do
            {
                Console.WriteLine("Add Assets if any in the meeting room.");
                Console.WriteLine("\nAssets List");
                var assetList = _assetManager.Get();
                DisplayList.DisplayEntityList(assetList);
                assetChoice = _userInputHandler.GetUserInputInt("Enter your choice(Press 9 to Skip/Continue): ");
                if (assetChoice == 9)
                {
                    return 0;
                }
                int qty = _userInputHandler.GetUserInputInt("Enter the quantity: ");

                var meetingRoomAsset = new MeetingRoomAsset
                {
                    MeetingRoomId = meetingRoomId,
                    AssetId = assetChoice,
                    Quantity = qty,
                };
                _meetingRoomAssetManager.Add(meetingRoomAsset);

            } while (assetChoice != 9);
            return 0;
        }

        private string GenerateMeetingRoomName(int meetingRoomListCount)
        {
            return "M" + meetingRoomListCount.ToString("D3");
        }
    }
}

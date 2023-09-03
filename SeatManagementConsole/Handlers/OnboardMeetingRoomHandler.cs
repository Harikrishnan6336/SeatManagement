﻿using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SeatManagementAPI.DTOs;
using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class OnboardMeetingRoomHandler
    {
        private readonly IFacilityManager _facilityManager;
        private readonly IEntityManager<MeetingRoom> _meetingRoomManager;
        private readonly IUserInputHandler _userInputHandler;
        public OnboardMeetingRoomHandler(IFacilityManager facilityManager,
                                         IEntityManager<MeetingRoom> meetingRoomManager,
                                         IUserInputHandler userInputHandler)
        {
            _facilityManager = facilityManager;
            _meetingRoomManager = meetingRoomManager;
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

            var facilityId = _userInputHandler.GetUserInputInt("Choose the facility id(where meeting rooms should be added):");
            var seatCount = _userInputHandler.GetUserInputInt("Enter the number of seats in the room");

            var meetingRoomListCount = _meetingRoomManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            int meetingRoomNameCount = meetingRoomListCount + 1;
            var meetingRoomName = "M" + meetingRoomNameCount;


            var meetingRoom = new MeetingRoom
            {
                FacilityId = facilityId,
                Name = meetingRoomName,
                SeatCount = seatCount,

            };
            _meetingRoomManager.Add(meetingRoom);
            Console.WriteLine("Your meeting room has been added successfully");
            _userInputHandler.WaitForUserInput();
        }
    }
}

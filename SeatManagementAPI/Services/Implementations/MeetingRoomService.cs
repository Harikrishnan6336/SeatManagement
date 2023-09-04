using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeetingRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddMeetingRoom(MeetingRoomDTO meetingRoomDTO)
        {
            var meetingRoom = new MeetingRoom()
            {
                Name = meetingRoomDTO.Name,
                FacilityId = meetingRoomDTO.FacilityId,
                SeatCount = meetingRoomDTO.SeatCount
            };
            _unitOfWork.MeetingRoom.Add(meetingRoom);
            _unitOfWork.Commit();
            return meetingRoom.Id;
        }

        public IEnumerable<MeetingRoom> GetMeetingRooms()
        {
            return _unitOfWork.MeetingRoom.GetAll();
        }
    }
}

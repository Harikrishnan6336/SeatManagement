using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IMeetingRoomService
    {
        IEnumerable<MeetingRoom> GetMeetingRooms();
        int AddMeetingRoom(MeetingRoomDTO meetingRoomDTO);
    }
}

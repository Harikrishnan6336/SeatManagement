using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IMeetingRoomAssetService
    {
        IEnumerable<MeetingRoomAsset> GetMeetingRoomAssets();
        void AddMeetingRoomAsset(MeetingRoomAssetDTO meetingRoomAssetDTO);
    }
}

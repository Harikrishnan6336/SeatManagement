using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class MeetingRoomAssetService : IMeetingRoomAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeetingRoomAssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddMeetingRoomAsset(MeetingRoomAssetDTO meetingRoomAssetDTO)
        {
            var meetingRoomAsset = new MeetingRoomAsset()
            {
                AssetId = meetingRoomAssetDTO.AssetId,
                MeetingRoomId = meetingRoomAssetDTO.MeetingRoomId,
                Quantity = meetingRoomAssetDTO.Quantity
            };
            _unitOfWork.MeetingRoomAsset.Add(meetingRoomAsset);
            _unitOfWork.Commit();
            return meetingRoomAsset.Id;
        }

        public IEnumerable<MeetingRoomAsset> GetMeetingRoomAssets()
        {
            return _unitOfWork.MeetingRoomAsset.GetAll();
        }
    }
}

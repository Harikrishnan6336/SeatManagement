using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetAssetsController : ControllerBase
    {
        private readonly IMeetingRoomAssetService _meetingRoomAssetService;
        public MeetingRoomAssetAssetsController(IMeetingRoomAssetService meetingRoomAssetService)
        {
            _meetingRoomAssetService = meetingRoomAssetService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_meetingRoomAssetService.GetMeetingRoomAssets());
        }

        [HttpPost]
        public IActionResult Post(MeetingRoomAssetDTO meetingRoomAssetDTO)
        {
            int id  = _meetingRoomAssetService.AddMeetingRoomAsset(meetingRoomAssetDTO);
            return Ok(id);
        }
    }
}

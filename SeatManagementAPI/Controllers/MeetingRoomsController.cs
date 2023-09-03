using Microsoft.AspNetCore.Mvc;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;
        public MeetingRoomsController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_meetingRoomService.GetMeetingRooms());
        }

        [HttpPost]
        public IActionResult Post(MeetingRoomDTO meetingRoomDTO)
        {
            _meetingRoomService.AddMeetingRoom(meetingRoomDTO);
            return Ok();
        }
    }
}

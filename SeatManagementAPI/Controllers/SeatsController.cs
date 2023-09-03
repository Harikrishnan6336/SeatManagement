using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Implementations;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_seatService.GetSeats());
        }

        [HttpGet("unoccupiedseats/{facilityId}")]
        public IActionResult GetUnoccupiedSeatsByFacility(int facilityId)
        {
            return Ok(_seatService.GetUnoccupiedSeatsByFacility(facilityId));
        }


        [HttpPost]
        public IActionResult Post(SeatDTO seatDTO)
        {
            _seatService.AddSeat(seatDTO);
            return Ok();
        }

        [HttpPatch("allocate")]
        public IActionResult Allocate(SeatAllocateDTO seat) 
        {
            _seatService.AllocateSeat(seat.SeatId, (int)seat.EmployeeId!);
            return Ok();
        }

        [HttpPatch("deallocate")]
        public IActionResult Deallocate(SeatAllocateDTO seat)
        {
            _seatService.DeallocateSeat(seat.SeatId, (int)seat.EmployeeId!);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Implementations;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinsController : ControllerBase
    {
        private readonly ICabinService _cabinService;

        public CabinsController(ICabinService service)
        {
            _cabinService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cabinService.GetCabins());
        }

        [HttpGet("unoccupiedcabins")]
        public IActionResult GetUnoccupiedCabins()
        {
            return Ok(_cabinService.GetUnoccupiedCabins());
        }

        [HttpPost]
        public IActionResult Post(CabinDTO cabinDTO)
        {
            int id  = _cabinService.AddCabin(cabinDTO);
            return Ok(id);
        }

        [HttpPatch("allocate")]
        public IActionResult Allocate(CabinAllocateDTO cabin)
        {
            _cabinService.AllocateCabin(cabin.CabinId, (int)cabin.EmployeeId!);
            return Ok();
        }
    }
}

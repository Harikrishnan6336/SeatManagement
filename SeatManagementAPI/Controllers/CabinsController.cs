using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
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

        [HttpPost]
        public IActionResult Post(CabinDTO cabinDTO)
        {
            _cabinService.AddCabin(cabinDTO);
            return Ok();
        }
    }
}

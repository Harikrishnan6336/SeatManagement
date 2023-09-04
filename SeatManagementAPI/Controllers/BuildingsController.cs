using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingsController(IBuildingService service)
        {
            _buildingService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_buildingService.GetBuildings());
        }

        [HttpPost]
        public IActionResult Post(BuildingDTO buildingDTO)
        {
            int id = _buildingService.AddBuilding(buildingDTO);
            return Ok(id);
        }
    }
}

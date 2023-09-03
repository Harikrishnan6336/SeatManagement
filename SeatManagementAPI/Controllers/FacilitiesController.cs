using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {

        private readonly IFacilityService _facilityService;

        public FacilitiesController(IFacilityService service)
        {
            _facilityService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_facilityService.GetFacilities());
        }

        [HttpGet("nomenclature")]
        public IActionResult GetNomenclature()
        {
            return Ok(_facilityService.GetFacilitiesNomenclature());
        }

        [HttpPost]
        public IActionResult Post(FacilityDTO facilityDTO)
        {
            _facilityService.AddFacility(facilityDTO);
            return Ok();
        }
    }
}


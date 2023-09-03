﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SeatManagement.DataAccess.Implementation;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService service)
        {
            _cityService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cityService.GetCities());
        }

        [HttpPost]
        public IActionResult Post(CityDTO cityDTO)
        {
            _cityService.AddCity(cityDTO);
            return Ok();
        }
    }


}

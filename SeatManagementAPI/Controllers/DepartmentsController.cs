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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService service)
        {
            _departmentService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_departmentService.GetDepartments());
        }

        [HttpPost]
        public IActionResult Post(DepartmentDTO departmentDTO)
        {
            int id = _departmentService.AddDepartment(departmentDTO);
            return Ok(id);
        }
    }
}

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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpPost]
        public IActionResult Post(EmployeeDTO employeeDTO)
        {
            int id = _employeeService.AddEmployee(employeeDTO);
            return Ok(id);
        }
    }
}

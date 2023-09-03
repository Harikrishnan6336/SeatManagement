//using Microsoft.AspNetCore.Mvc;
//using SeatManagementAPI.Services.Interfaces;

//namespace SeatManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReportsController : Controller
//    {
//        private readonly IReportService _reportService;
//        public ReportsController(IReportService reportService)
//        {
//            _reportService = reportService;
//        }

//        [HttpGet("allocatedlist")]
//        public IActionResult GetAllocated()
//        {
//            try
//            {
//                return Ok(_reportService.GetAllocatedList());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpGet("deallocatedlist")]
//        public IActionResult GetDealloactedList()
//        {
//            try
//            {
//                return Ok(_reportService.GetUnallocatedList());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService service)
        {
            _assetService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_assetService.GetAssets());
        }

        [HttpPost]
        public IActionResult Post(AssetDTO assetDTO)
        {
            _assetService.AddAsset(assetDTO);
            return Ok();
        }

        //[HttpPut]
        //public IActionResult Put(AssetDTO assetDTO)
        //{
        //    _assetService.AddAsset(assetDTO);
        //    return Ok();
        //}
    }
}

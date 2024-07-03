using DT.Model.Data.Location;
using DT.Services;
using Microsoft.AspNetCore.Mvc;

namespace DT.Controllers
{
    [ApiController]
    [Route("Region")]
    public class RegionController : ControllerBase
    {
        IRegionService _regionService;

        public RegionController(IRegionService regionService) 
        {
            _regionService = regionService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRegion(Region region)
        {
            await _regionService.AddAsync(region);
            return Ok();
        }
    }
}

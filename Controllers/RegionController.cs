using DT.Model.Data.Location;
using DT.Services;
using DTO;
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

        [HttpGet]
        [Route("Get")]
        // TODO потом возвращать DTO
        public async Task<DTO.RegionDTO> Get(Guid id)
        {
            return await _regionService.GetAsync(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRegion(RegionDTO region)
        {
            var regionDTO = await _regionService.AddAsync(region);
            if (regionDTO != null)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            if (await _regionService.DeleteAsync(id))
                return Ok();
            return NotFound();
        }

        // ---------------------------------------------

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<RegionDTO>> GetAll()
        {
            return await _regionService.GetAllAsync();
        }


    }

}

using DT.Model.Data.Location;
using DT.Services;
using Microsoft.AspNetCore.Mvc;

namespace DT.Controllers
{
    [ApiController]
    [Route("City")]
    public class CityController : ControllerBase
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("Get")]
        // TODO потом возвращать DTO
        public async Task<City> Get(Guid id)
        {
            return await _cityService.GetAsync(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCity(City city, Guid regionGuid)
        {
            await _cityService.AddAsync(city, regionGuid);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (await _cityService.DeleteAsync(id))
                return Ok();
            return NotFound();
        }

        // ---------------------------------------------

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<City>> GetAll()
        {
            return await _cityService.GetAllAsync();
        }


    }

}

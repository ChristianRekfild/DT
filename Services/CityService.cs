using DT.CustomExceprions;
using DT.Model.Data.Location;
using DT.Represitory;
using System.Collections;

namespace DT.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;

        public CityService(ICityRepository cityRepository, IRegionRepository regionRepository)
        {
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
        }

        public Task<City> GetAsync(Guid id)
        {
            return _cityRepository.GetAsync(id);
        }

        public async Task<City> AddAsync(City city, Guid regionGuid)
        {
            var region = await _regionRepository.GetAsync(regionGuid);
            if (region is null)
                throw new RegionNotFoundExceprion("Запращиваемый Регион по указанному Guid'у не найден");

            city.Region = region;
            return await _cityRepository.AddAsync(city);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _cityRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}

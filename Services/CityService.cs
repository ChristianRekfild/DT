using AutoMapper;
using DT.CustomExceprions;
using DT.Model.Data.Location;
using DT.Represitory;
using DTO;
using System.Collections;

namespace DT.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _autoMapperDT;

        public CityService(ICityRepository cityRepository, IRegionRepository regionRepository, IMapper autoMapperDT)
        {
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
            _autoMapperDT = autoMapperDT;
        }

        public async Task<CityDTO> GetAsync(Guid id)
        {
            City city = await _cityRepository.GetWithIncludesAsync(id);
            if (city is null)
                return null;

            CityDTO cityDTO = _autoMapperDT.Map<CityDTO>(city);

            return cityDTO;
        }

        public async Task<CityDTO> AddAsync(CityDTO_WithoutRegion city, Guid regionGuid)
        {
            var region = await _regionRepository.GetAsync(regionGuid);
            if (region is null)
                throw new RegionNotFoundException("Запрашиваемый Регион по указанному Guid'у не найден");

            City newCity = _autoMapperDT.Map<City>(city);

            newCity.Region = region;
            var addedCity = await _cityRepository.AddAsync(newCity);
            CityDTO returnedCityDTO = _autoMapperDT.Map<CityDTO>(addedCity);

            return returnedCityDTO;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _cityRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CityDTO>> GetAllAsync()
        {
            var cities = await _cityRepository.GetAllAsync();

            var citiesDTO = _autoMapperDT.Map<IEnumerable<CityDTO>>(cities);
            return citiesDTO;
        }
    }
}

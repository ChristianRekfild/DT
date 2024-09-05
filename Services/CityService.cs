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

        public async Task<DTO.CityDTO> GetAsync(Guid id)
        {
            City city = await _cityRepository.GetAsync(id);
            if (city is null)
                return null;

            CityDTO cityDTO = _autoMapperDT.Map<CityDTO>(city);

            return cityDTO;
        }

        public async Task<City> AddAsync(City city, Guid regionGuid)
        {
            var region = await _regionRepository.GetAsync(regionGuid);
            if (region is null)
                throw new RegionNotFoundException("Запращиваемый Регион по указанному Guid'у не найден");

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

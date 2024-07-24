//using DT.CustomMapper;
using AutoMapper;
using DT.CustomExceprions;
using DT.Mapper;

//using DT.Mapper;
using DT.Model.Data.Location;
using DT.Represitory;
using DTO;
using System;
using System.Collections;

namespace DT.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _autoMapperDT;

        public RegionService(IRegionRepository regionRepository, IMapper autoMapperDT)
        {
            _regionRepository = regionRepository;
            _autoMapperDT = autoMapperDT;
        }

        public async Task<RegionDTO> GetAsync(Guid id)
        {
            var regionEntity = await _regionRepository.GetAsync(id);
            if (regionEntity is null)
                return null;

            RegionDTO regionDTO = _autoMapperDT.Map<RegionDTO>(regionEntity);

            return regionDTO;
        }

        public async Task<RegionDTO> AddAsync(RegionDTO regionDTO)
        {
            // Проверяем наличие такого региона в БД по названию
            var entityInDB = await _regionRepository.SelectFirstAsync(x => x.Name == regionDTO.Name.Trim());
            if (entityInDB != null)
                return null;

            // Если в БД есть такой Guid - то создаём новый для того, чтобы в БД не было конфликтов. Зачем оно нам?)
            entityInDB = await _regionRepository.GetAsync(regionDTO.Id);
            if (entityInDB != null)
                regionDTO.Id = Guid.NewGuid();

            Region region = new Region();
            region.Name = regionDTO.Name.Trim();
            region.CreatedAt = DateTime.Now;
            region.UpdatedAt = DateTime.Now;

            Region addedRegion = await _regionRepository.AddAsync(region);
            if (addedRegion is null)
                throw new RegionAddException("Ошибка добавления региона в базу данных");

            RegionDTO addeedRegionDTO = _autoMapperDT.Map<RegionDTO>(addedRegion);

            return addeedRegionDTO;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _regionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RegionDTO>> GetAllAsync()
        {
            List<RegionDTO> listOfRegionsDTO = new List<RegionDTO>();

            var regions = await _regionRepository.GetAllAsync();

            listOfRegionsDTO = _autoMapperDT.Map<List<RegionDTO>>(regions);

            return listOfRegionsDTO;

        }
    }
}

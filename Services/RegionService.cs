//using DT.CustomMapper;
using AutoMapper;
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

        public async Task<Region> AddAsync(Region region)
        {
            return await _regionRepository.AddAsync(region);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _regionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }
    }
}

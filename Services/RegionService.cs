using DT.Model.Data.Location;
using DT.Represitory;
using System.Collections;

namespace DT.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public Task<Region> GetAsync(Guid id)
        {
            return _regionRepository.GetAsync(id);
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

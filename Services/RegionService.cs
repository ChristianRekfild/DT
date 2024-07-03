using DT.Model.Data.Location;
using DT.Represitory;

namespace DT.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<Region> AddAsync(Region region)
        {
            return await _regionRepository.AddAsync(region);
        }
    }
}

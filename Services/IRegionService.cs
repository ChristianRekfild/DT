using DT.Model.Data.Location;
using DTO;

namespace DT.Services
{
    public interface IRegionService
    {
        public Task<Region> AddAsync(Region region);
        public Task<RegionDTO> GetAsync(Guid id);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<Region>> GetAllAsync();
    }
}

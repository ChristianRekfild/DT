using DT.Model.Data.Location;

namespace DT.Services
{
    public interface IRegionService
    {
        public Task<Region> AddAsync(Region region);
        public Task<Region> GetAsync(Guid id);
        public Task<bool> DeleteAsync(Guid id);
    }
}

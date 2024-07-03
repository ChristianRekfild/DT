using DT.Model.Data.Location;

namespace DT.Services
{
    public interface IRegionService
    {
        public Task<Region> AddAsync(Region region);
    }
}

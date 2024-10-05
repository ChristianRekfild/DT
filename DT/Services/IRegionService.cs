using DT.Model.Data.Location;
using DTO;

namespace DT.Services
{
    public interface IRegionService
    {
        public Task<RegionDTO> AddAsync(RegionDTO regionDTO);
        public Task<RegionDTO> GetAsync(Guid id);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<RegionDTO>> GetAllAsync();
    }
}

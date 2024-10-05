using DT.Model.Data.Location;
using DTO;

namespace DT.Services
{
    public interface ICityService
    {
        public Task<DTO.CityDTO> AddAsync(CityDTO_WithoutRegion city, Guid regionGuid);
        public Task<DTO.CityDTO> GetAsync(Guid id);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<CityDTO>> GetAllAsync();
    }
}

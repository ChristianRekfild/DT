using DT.Model.Data.Location;

namespace DT.Services
{
    public interface ICityService
    {
        public Task<City> AddAsync(City city, Guid regionGuid);
        public Task<City> GetAsync(Guid id);
        public Task<bool> DeleteAsync(Guid id);
        public Task<IEnumerable<City>> GetAllAsync();
    }
}
